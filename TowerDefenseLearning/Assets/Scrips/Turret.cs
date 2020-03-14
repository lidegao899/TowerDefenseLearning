using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotateSpeed = 90f;

    [Header("General")]
    public float fireRange = 15f;

    [Header("Use Bullets (deafult)")]
    public float fireRate = 2f;

    public float fireCountDown = 1f;
    public GameObject bulletPrefab;

    [Header("Use Laser")]
    public bool useLaser = false;

    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light laserLight;
    public int damagePerSec = 30;
    public float slowDownRatio = 0.5f;

    [Header("Unity Setup Fields")]
    private GameObject target;

    public GameObject rotatePart;

    public Transform firePoint;

    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                lineRenderer.enabled = false;
                laserEffect.Stop();
                laserLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            UseLaser();
        }
        else
        {
            if (fireCountDown <= 0)
            {
                fireCountDown = fireRate;
                Shoot();
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    private void LockOnTarget()
    {
        Vector3 direction = target.transform.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(rotatePart.transform.rotation, lookRotation, rotateSpeed * Time.deltaTime).eulerAngles;

        rotatePart.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject shortestEnemy = null;

        foreach (GameObject item in enemies)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if (shortestDistance > distance)
            {
                shortestDistance = distance;
                shortestEnemy = item;
            }

            if (target != null && shortestDistance > fireRange)
            {
                target.GetComponent<EnemyMovement>().ReturnNomalSpeed();
                target = null;
                //targetEnemy.Movement.ReturnNomalSpeed();
            }
            else
            {
                target = shortestEnemy;
                //targetEnemy = target.GetComponent<Enemy>();
            }
            //Debug.Log(target);
        }
    }

    private void UseLaser()
    {
        target.GetComponent<Enemy>().TakeDamage(damagePerSec * Time.deltaTime);
        target.GetComponent<EnemyMovement>().SlowDown(slowDownRatio);
        //targetEnemy.Movement.SlowDown(slowDownRatio);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserEffect.Play();
            laserLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.transform.position);

        Vector3 dir = firePoint.position - target.transform.position;

        laserEffect.transform.position = target.transform.position + dir.normalized * 1f;

        laserEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireRange);
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null && target != null)
        {
            bullet.SetTarget(target.transform);
        }
    }
}
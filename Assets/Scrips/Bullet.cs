using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject explodeEffect;

    public float speed = 100;

    public float exploadRadius = 0f;

    public int damage = 50;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float moveDiatanceByFrame = speed * Time.deltaTime;

        if (dir.magnitude <= moveDiatanceByFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * moveDiatanceByFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = Instantiate(explodeEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        if (exploadRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        { 
            e.TakeDamage(damage);
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploadRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploadRadius);
    }
}

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float initSpeed = 20;

    [HideInInspector]
    public float speed = 20f;

    private int wayPointIndex = 0;

    public float health = 100;

    private Transform target;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 dis = target.transform.position - transform.position;

        transform.Translate(dis.normalized * speed * Time.deltaTime, Space.World);

        if (dis.magnitude < 0.5f)
        {
            if (wayPointIndex == WayPoints.points.Length - 1)
            {
                EndPath();
                return;
            }
            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void SlowDown(float ratio)
    {
        speed = ratio * initSpeed;
    }

    public void ReturnNomalSpeed()
    {
        speed = initSpeed;
    }
}
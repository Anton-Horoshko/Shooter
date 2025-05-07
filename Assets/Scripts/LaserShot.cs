using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserShot : MonoBehaviour
{
    public Transform playerCamera;
    public int maxBounces = 3;
    public int damageAmount = 25;
    public float maxDistance = 30f;
    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !lineRenderer.enabled)
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Vector3 origin = playerCamera.position - new Vector3(0, 0, -1f);
        Vector3 direction = playerCamera.forward;

        lineRenderer.enabled = true;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, origin);

        int bounces = 0;
        while (bounces < maxBounces)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance))
            {
                bounces++;
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(bounces, hit.point);

                if (hit.collider.CompareTag("Enemy"))
                {
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                    }
                    break;
                }

                origin = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(bounces + 1, origin + direction * maxDistance);
                break;
            }
        }
            Invoke("DisableLaser", 0.5f);
    }
    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

}
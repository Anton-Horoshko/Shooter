using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserShot : MonoBehaviour
{
    public Transform playerCamera;
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
        while (bounces < PlayerStats.Instance.maxShootBounces)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit, PlayerStats.Instance.maxShootDistance))
            {
                bounces++;
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(bounces, hit.point);

                if (hit.collider.CompareTag("Enemy"))
                {
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(PlayerStats.Instance.damage);
                    }
                    break;
                }

                origin = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(bounces + 1, origin + direction * PlayerStats.Instance.maxShootDistance);
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
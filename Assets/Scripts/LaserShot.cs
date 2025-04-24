using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserShot : MonoBehaviour
{
    public Transform playerCamera;
    public int maxBounces = 3;
    public float maxDistance = 30f;
    public LineRenderer lineRenderer;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Vector3 origin = playerCamera.position;
        Vector3 direction = playerCamera.forward;

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
                    Destroy(hit.collider.gameObject);
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
    }
}
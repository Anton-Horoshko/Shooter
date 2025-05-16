using UnityEngine;
using System.Collections;
using Unity.Burst.CompilerServices;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
public class LaserShot : MonoBehaviour
{
    public TextMeshPro damagePrefab;
    public Transform playerCamera;
    public Transform startPoint;
    public LineRenderer lineRenderer;
    public float fadeDuration = 0.5f;

    private Material laserMaterial;
    private Coroutine fadeCoroutine;

    void Start()
    {
        lineRenderer.enabled = false;
        laserMaterial = lineRenderer.material;
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
        Vector3 origin = startPoint.position;
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
                        ShowDamage(damagePrefab, hit.point, playerCamera.rotation);

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

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeLaser());
    }

    public void ShowDamage(TextMeshPro damagePrefab, Vector3 damageTextPosition, Quaternion quaternion)
    {
        TextMeshPro textInstance = Instantiate(damagePrefab, damageTextPosition += Vector3.up * 1.3f, quaternion);
        textInstance.text = PlayerStats.Instance.damage.ToString() + "dmg!";
        Destroy(textInstance.gameObject, 1f);
    }

    IEnumerator FadeLaser()
    {
        float elapsed = 0f;
        Color color = laserMaterial.color;
        float startAlpha = color.a;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, 0f, t);
            laserMaterial.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = startAlpha;
        laserMaterial.color = color;
        lineRenderer.enabled = false;
    }
}

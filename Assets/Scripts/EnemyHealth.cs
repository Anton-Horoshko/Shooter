using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public PlayerUpgreates playerUpgreates;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Враг получил урон. Текущее здоровье: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        //playerUpgreates.AddUpgreatePoint(1);
        Debug.Log("Враг умер!");
    }
}

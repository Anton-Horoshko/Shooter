using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshPro healthText;

    public void TakeDamage(int damage)
    {
        PlayerStats.Instance.maxHP -= damage;
        healthText.text = "HP: " + PlayerStats.Instance.maxHP.ToString();
        if (PlayerStats.Instance.maxHP <= 0)
        {
            PlayerStats.Instance.maxHP = 0;
            // Add player death logic here if needed
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    // Optional: Add debug to verify collision is detected
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player is colliding with Enemy");
        }
    }
}

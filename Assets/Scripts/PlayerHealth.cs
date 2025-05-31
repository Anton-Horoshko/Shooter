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
            Debug.Log("Player has died");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player is colliding with Enemy");
            TakeDamage(20);
        }
    }
}

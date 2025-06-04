using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshPro healthText;
    public GameObject deathMenu;

    public void TakeDamage(int damage)
    {
        PlayerStats.Instance.maxHP -= damage;
        healthText.text = "HP: " + PlayerStats.Instance.maxHP.ToString();
        if (PlayerStats.Instance.maxHP <= 0)
        {
            PlayerStats.Instance.maxHP = 0;
            OnPlayerDeath();
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

    public void OnPlayerDeath()
    {
        PlayerStats.Instance.isDead = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        deathMenu.SetActive(true);

    }
}

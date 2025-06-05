using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public UpGrade upGrade;

    public TMPro.TextMeshProUGUI skillPointsText;
    public TextMeshPro healthText;
    public TextMeshPro xpText;

    public int currentLevel = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;
    public int skillPoints= 0;
    public int maxHP= 100;
    public int damage = 25;
    public int maxShootBounces = 1;
    public float moveSpeed = 6f;
    public float jumpHeight = 3f;
    public float maxShootDistance = 30f;

    public bool isDead = false;

    void Start()
    {
        Instance = this;
        isDead = false;
        Time.timeScale = 1f;
        ResetStats();
    }

    void Update()
    {
        
    }

    public void GainXP(int points)
    {
        currentXP += points;

        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }

        xpText.text = "XP: " + currentXP + " / " + xpToNextLevel;
    }

    void LevelUp()
    {
        currentLevel++;
        skillPoints++;

        skillPointsText.text = "Points : " + skillPoints;
        upGrade.ToggleUpgrade();

        xpToNextLevel += Mathf.RoundToInt(xpToNextLevel * 0.05f);
        xpText.text = "XP: " + currentXP + " / " + xpToNextLevel;
    }

    public void UpgradeDamage()
    {
        if (skillPoints > 0)
        {
            damage += 10;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
        upGrade.ToggleUpgrade();
    }

    public void UpgradeHP()
    {
        if (skillPoints > 0)
        {
            maxHP += 20;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;
            healthText.text = "HP: " + maxHP.ToString();

        }
        upGrade.ToggleUpgrade();
    }

    public void UpgradeSpeed()
    {
        if (skillPoints > 0)
        {
            moveSpeed += 3;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
        upGrade.ToggleUpgrade();
    }

    public void UpgradeJumpHeight()
    {
        if (skillPoints > 0)
        {
            jumpHeight += 3;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
        upGrade.ToggleUpgrade();
    }

    public void UpgradeMaxShootDistance()
    {
        if (skillPoints > 0)
        {
            maxShootDistance += 5;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
        upGrade.ToggleUpgrade();
    }

    public void UpgradeMaxShootBounces()
    {
        if (skillPoints > 0)
        {
            maxShootBounces += 1;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
        upGrade.ToggleUpgrade();
    }

    public void ResetStats()
    {
        // Reset player stats
        PlayerStats.Instance.currentLevel = 1;
        PlayerStats.Instance.currentXP = 0;
        PlayerStats.Instance.skillPoints = 0;
        PlayerStats.Instance.maxHP = 100;
        PlayerStats.Instance.damage = 25;
        PlayerStats.Instance.maxShootBounces = 1;
        PlayerStats.Instance.moveSpeed = 6f;
        PlayerStats.Instance.jumpHeight = 3f;
        PlayerStats.Instance.maxShootDistance = 30f;
        // Update UI
        PlayerStats.Instance.skillPointsText.text = "Points : " + PlayerStats.Instance.skillPoints;
        PlayerStats.Instance.healthText.text = "Health: " + PlayerStats.Instance.maxHP;
    }
}
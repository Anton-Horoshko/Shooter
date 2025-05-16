using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public TMPro.TextMeshProUGUI skillPointsText;

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

    void Start()
    {
        Instance = this;
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
    }

    void LevelUp()
    {
        currentLevel++;
        skillPoints++;

        skillPointsText.text = "Points : " + skillPoints;

        xpToNextLevel += Mathf.RoundToInt(xpToNextLevel * 0.25f);
    }

    public void UpgradeDamage()
    {
        if (skillPoints > 0)
        {
            damage += 10;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }

    public void UpgradeHP()
    {
        if (skillPoints > 0)
        {
            maxHP += 20;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }

    public void UpgradeSpeed()
    {
        if (skillPoints > 0)
        {
            moveSpeed += 3;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }

    public void UpgradeJumpHeight()
    {
        if (skillPoints > 0)
        {
            jumpHeight += 3;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }

    public void UpgradeMaxShootDistance()
    {
        if (skillPoints > 0)
        {
            maxShootDistance += 5;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }

    public void UpgradeMaxShootBounces()
    {
        if (skillPoints > 0)
        {
            maxShootBounces += 1;
            skillPoints--;
            skillPointsText.text = "Points : " + skillPoints;

        }
    }
}
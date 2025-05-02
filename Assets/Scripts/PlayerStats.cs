using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
        xpToNextLevel += Mathf.RoundToInt(xpToNextLevel * 0.25f);
    }

    public void UpgradeDamage()
    {
        damage += 10;
        skillPoints--;
    }

    public void UpgradeHP()
    {
        maxHP += 20;
        skillPoints--;
    }

    public void UpgradeSpeed()
    {
        moveSpeed += 3;
        skillPoints--;
    }

    public void UpgradeJumpHeight()
    {
        jumpHeight += 3;
        skillPoints--;
    }

    public void UpgradeMaxShootDistance()
    {
        maxShootDistance += 5;
        skillPoints--;
    }

    public void UpgradeMaxShootBounces()
    {
        maxShootBounces += 1;
        skillPoints--;
    }
}
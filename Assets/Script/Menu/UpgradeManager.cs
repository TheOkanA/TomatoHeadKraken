using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public PlayerHealthBar playerHealthBar;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;
    public GameObject panel;
    public void UpgradeHealth()
    {
        playerHealthBar.healthBar.maxValue = 20;
        playerHealthBar.maxHealth = 20;
        playerHealthBar.health = 20;
        panel.SetActive(false);
    }

    public void UpgradeSpeed()
    {
        playerMovement.speed = 3;
        panel.SetActive(false);
    }

    public void UpgradeAttackCD()
    {
        playerAttack.attackSpeed = 0.50f;
        panel.SetActive(false);
    }
}

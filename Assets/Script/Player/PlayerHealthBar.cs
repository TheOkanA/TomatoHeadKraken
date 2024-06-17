using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public int health;
    public int maxHealth = 10;
    void Start()
    {
        health = maxHealth;
        //healthBar = GetComponent<Slider>();

        healthBar.value = health;
    }

    void Update()
    {
        healthBar.value = health;
    }
}

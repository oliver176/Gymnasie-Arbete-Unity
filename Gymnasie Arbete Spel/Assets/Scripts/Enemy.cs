﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : DamageDealer
{
    protected float currentHP;
    protected float xpWorth = 100;
    protected float baseHP;
    protected float hpModifier;

    protected float fireRate;
    protected float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected float TakeDamage(float amount, float currentHP, float baseHP, Image healthBar)
    {
        currentHP -= amount;
        healthBar.fillAmount = currentHP / baseHP;

        return healthBar.fillAmount;
    }

    protected bool DeadCheck(float hp)
    {
        if (hp <= 0)
        {
            XpReward(xpWorth);
            return true;
        }
        else return false;
    }
}

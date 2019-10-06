﻿using UnityEngine;
using System.Collections;

public class HealthManager : PlayerStats
{
    float shieldPerSecond;
    bool waitingForShield;

    // Start is called before the first frame update
    private void Start()
    {
        //start värden, fullt hp och 0 shield
        playerMaxHealth = 90 + (10 * level);
        playerCurrentHealth = playerMaxHealth;
        playerMaxShield = 25;
        playerCurrentShield = playerMaxShield;
        shieldRechargeDelay = 5;
        shieldPerSecond = playerMaxShield / shieldRechargeDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        playerMaxHealth = 90 + (10 * level);
        //Debug.Log("player level: " + level);

        if (waitingForShield == false)
        {
            RechargeShield();
        }
        if (playerCurrentShield < 0)
        {
            playerCurrentShield = 0;
        }
        if (playerCurrentShield > playerMaxShield)
        {
            playerCurrentShield = playerMaxShield;
        }
        if (playerCurrentHealth < 0) //om player dör, avaktivera player och aktivera restartUI
        {
            gameObject.SetActive(false);
        }
    }

    void RechargeShield()
    {
        playerCurrentShield += shieldPerSecond * Time.deltaTime;
    }

    IEnumerator Timer()
    {
        waitingForShield = true;
        yield return new WaitForSeconds(5);
        waitingForShield = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageDealer DD = other.gameObject.GetComponent<DamageDealer>();

        if (other.gameObject.GetComponent<DamageDealer>().GetType().IsSubclassOf(typeof(DamageDealer)))
        {
            Debug.Log("MinDmg, MaxDmg " + (DD.minDmg * DD.dmgModifier) + ", " + (DD.maxDmg * DD.dmgModifier));
            HurtPlayer(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
            StartCoroutine(Timer());
        }
    }

    public void HurtPlayer(float DamageToGive) //metod som skadar player
    {
        if (DamageToGive > playerCurrentShield)
        {
            float x = DamageToGive - playerCurrentShield;  //Tar först bort playerns shieldamount på dmg

            playerCurrentHealth -= x;
        }
        if (playerCurrentShield > 0)
        {
            playerCurrentShield -= DamageToGive;
        }
    }

    public void RestartGame() //aktivera player och avaktivera UI, sätt tillbaks hp värdet;
    {
        gameObject.SetActive(true);
        SetMaxHealth();
    }

    public void SetMaxHealth() //sätt hp till max
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void HealPlayer(int HealingAmount) //+hp till player
    {
        playerCurrentHealth += HealingAmount;
    }

    public void ShieldPlayer(int ShieldAmount) //+shield till player
    {
        playerCurrentShield += ShieldAmount;
    }
}

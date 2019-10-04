using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public float playerMaxShield;
    public float playerCurrentShield;


    // Start is called before the first frame update
    private void Start()
    {
        //start värden, fullt hp och 0 shield
        SetMaxHealth();
        playerCurrentShield = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerCurrentHealth < 0) //om player dör, avaktivera player och aktivera restartUI
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bool doesDmg = typeof(DamageDealer).IsAssignableFrom(other.gameObject.GetType());

        if (doesDmg == true)
        {
            HurtPlayer(Random.Range(damageDealer.minDmg, damageDealer.maxDmg));
        }
        else return;
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

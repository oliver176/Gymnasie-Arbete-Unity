using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int playerMaxShield;
    public int playerCurrentShield;

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

    public void HurtPlayer(int DamageToGive) //metod som skadar player
    {
        if (DamageToGive > playerCurrentShield)
        {
            int x = DamageToGive - playerCurrentShield;  //Tar först bort playerns shieldamount på dmg

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

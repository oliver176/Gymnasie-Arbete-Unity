using UnityEngine;

public class HealthManager : PlayerStats
{
    // Start is called before the first frame update
    private void Start()
    {
        //start värden, fullt hp och 0 shield
        playerMaxHealth = 100;
        playerCurrentHealth = playerMaxHealth;
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
        DamageDealer DD = other.gameObject.GetComponent<DamageDealer>();

        if (other.gameObject.GetComponent<DamageDealer>().GetType().IsSubclassOf(typeof(DamageDealer)))
        {
            Debug.Log("MinDmg, MaxDmg " + (DD.minDmg * DD.dmgModifier) + ", " + (DD.maxDmg * DD.dmgModifier));
            HurtPlayer(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
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

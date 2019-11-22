using UnityEngine;
using UnityEngine.UI;

public class Enemy : DamageDealer
{
    protected float currentHP;
    protected float xpWorth = 100;
    protected float baseHP;
    protected float hpModifier;

    protected float fireRate;
    protected float counter;

    protected bool xpGiven = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected float TakeDamage(float amount, float currentHP, float baseHP)
    {
        currentHP -= amount;
        float hpFill= currentHP / baseHP;

        return hpFill;
    }

    protected bool DeadCheck(float hp)
    {
        if (hp <= 0 && !xpGiven)
        {
            XpReward(xpWorth);
            xpGiven = true;
            return true;
        }
        else return false;
    }
}

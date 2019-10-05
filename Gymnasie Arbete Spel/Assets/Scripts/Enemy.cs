using UnityEngine;

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

    protected void DeadCheck(GameObject Enemy, float hp)
    {
        if (hp <= 0)
        {
            Destroy(Enemy);
            XpReward(xpWorth);
        }
    }
}

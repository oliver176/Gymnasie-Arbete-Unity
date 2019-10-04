using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageDealer
{
    protected int currentHP;
    protected float xpGain;
    protected int baseHP;
    protected int hpModifier;

    protected float dmgModifier;

    protected float fireRate;
    protected float counter;

    
    protected int enemyLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageDealer
{
    protected int currentHP;
    protected float xpGain;
    protected int baseHP;
    protected int hpModifier;

    protected float fireRate;
    protected float counter;
    
    protected int enemyLevel;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats playerStats = Player.GetComponent<PlayerStats>();
        
        enemyLevel = playerStats.level;
        baseHP = baseHP + (hpModifier * enemyLevel);
        currentHP = baseHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

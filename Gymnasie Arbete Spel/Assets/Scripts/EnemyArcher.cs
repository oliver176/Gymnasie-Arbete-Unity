using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    int currentHP;
    public int baseHP = 90;
    public int hpModifier = 12;
    public float dmgModifier = 0.008f;
    public float minDmg = 2000;
    public float maxDmg = 3500;
    public float speedModifier = 0;
    public int playerLevel;
    int enemyLevel;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats playerStats = Player.GetComponent<PlayerStats>();
        enemyLevel = playerStats.level;
        currentHP = baseHP + (hpModifier * enemyLevel);
        dmgModifier *= enemyLevel;
        minDmg *= dmgModifier;
        maxDmg *= dmgModifier;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
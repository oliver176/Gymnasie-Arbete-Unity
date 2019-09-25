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

    public float fireRate;
    private float counter;

    int playerLevel;
    int enemyLevel;

    public GameObject Arrow;
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

        counter = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter < 0)
        {
            Instantiate(Arrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            counter = fireRate;
        }
    }
}
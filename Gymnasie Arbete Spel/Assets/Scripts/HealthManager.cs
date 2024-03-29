﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : PlayerStats
{
    private float shieldPerSecond;
    private bool waitingForShield;
    private Animator anim;
    public Transform playerSpawnPoint;
    private bool respawned = false;
    public Image healthBar;
    public Image shieldBar;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        healthBar.fillAmount = playerCurrentHealth / playerMaxHealth;
        shieldBar.fillAmount = playerCurrentShield / playerMaxShield;

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
        if (playerCurrentHealth < 0)
        {
            respawned = false;

            m_FacingRight = true;

            anim.SetBool("IsDead", true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;

            Scene scene = SceneManager.GetActiveScene();
            Player.level = 0;
            SceneManager.LoadScene(scene.name);
            //StartCoroutine(RespawnTimer());
        }
    }

    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSecondsRealtime(5);
        if (!respawned)
        {
            print("wait is over");
            transform.position = playerSpawnPoint.transform.position;
            gameObject.GetComponent<PlayerMovement>().enabled = true;

            playerCurrentHealth = playerMaxHealth;
            playerCurrentShield = 0;
            anim.SetBool("IsDead", false);
            anim.SetTrigger("PlayerRespawn");

            respawned = true;
        }
    }

    private void RechargeShield()
    {
        playerCurrentShield += shieldPerSecond * Time.deltaTime;
    }

    private IEnumerator DeathTimer()
    {
        Debug.Log("");
        yield return new WaitForSeconds(5);
    }

    private IEnumerator Timer()
    {
        waitingForShield = true;
        yield return new WaitForSeconds(5);
        waitingForShield = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageDealer DD = other.gameObject.GetComponent<DamageDealer>();

        //blir null om det inte har en polygon collider på sig.
        PolygonCollider2D polygonCollider2D = other.gameObject.GetComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
        PolygonCollider2D p_collider;
        p_collider = other.gameObject.GetComponent<PolygonCollider2D>();

        if (other.gameObject.tag == "EnemyArrow")
        {
            HurtPlayer(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
            StartCoroutine(Timer());
        }
        else if (polygonCollider2D != null && p_collider.enabled) //skeleton warriors slag
        {
            HurtPlayer(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
            StartCoroutine(Timer());
        }
        /*if (other.gameObject.GetComponent<DamageDealer>().GetType().IsSubclassOf(typeof(DamageDealer)))
        {
            Debug.Log("MinDmg, MaxDmg " + (DD.minDmg * DD.dmgModifier) + ", " + (DD.maxDmg * DD.dmgModifier));
            Debug.Log(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
            HurtPlayer(Random.Range(DD.minDmg * DD.dmgModifier, DD.maxDmg * DD.dmgModifier));
            StartCoroutine(Timer());
        }*/
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
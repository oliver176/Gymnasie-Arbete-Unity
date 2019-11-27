using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Warrior : Enemy
{
    bool withinRange = false;
    private Animator anim;
    public Image healthBar;
    private Rigidbody2D rb2d;

    private void Start()
    {
        anim = GetComponent<Animator>();

        hpModifier = 15;
        baseHP = 90 + (hpModifier * SetLevel());
        currentHP = baseHP;

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            healthBar.fillAmount = TakeDamage(10, currentHP, baseHP);
            currentHP -= 10;
        }

        isDead = DeadCheck(currentHP);
        if (isDead)
        {
            rb2d.gravityScale = 0;
            anim.SetBool("WarriorDead", true);
            StartCoroutine("DeathTimer");
        }
    }
    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("WarriorAttackRange", false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //blir null om det inte har en polygon collider på sig.
        PolygonCollider2D polygonCollider2D = other.gameObject.GetComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;

        if (other.gameObject.tag == "MagicAttack")
        {
            float dmg = Random.Range(PlayerStats.minMagiDmg, PlayerStats.maxMagiDmg);
            Debug.Log("DAMAGE = " + dmg);
            Debug.Log("HP: " + currentHP);
            healthBar.fillAmount = TakeDamage(dmg, currentHP, baseHP);
            currentHP -= dmg;
        }
        else if (polygonCollider2D != null)
        {
            float dmg = Random.Range(PlayerStats.minPhysDmg, PlayerStats.minPhysDmg);
            healthBar.fillAmount = TakeDamage(dmg, currentHP, baseHP);
            currentHP -= dmg;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //inom collidern som representerar range
        {
            anim.SetBool("WarriorAttackRange", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //när player lämnar collidern
        {
            anim.SetBool("WarriorAttackRange", false);
            StartCoroutine("Timer");
        }
    }
}
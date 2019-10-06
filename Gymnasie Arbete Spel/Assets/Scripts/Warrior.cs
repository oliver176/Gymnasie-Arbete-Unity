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
            healthBar.fillAmount = TakeDamage(10, currentHP, baseHP, healthBar);
            currentHP -= 10;
        }
        isDead = DeadCheck(currentHP);
        if (isDead)
        {
            rb2d.gravityScale = 0;
            anim.SetBool("WarriorDead", true);
            StartCoroutine("DeathTimer");
        }
        if (withinRange) //om player inom range
        {

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //inom collidern som representerar range
        {
            withinRange = true;
            anim.SetBool("WarriorAttackRange", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //när player lämnar collidern
        {
            withinRange = false;
            StartCoroutine("Timer");
        }
    }
}
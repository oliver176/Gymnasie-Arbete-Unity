using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Warrior : Enemy
{
    bool withinRange = false;
    private Animator anim;
    public Image healthBar;

    private void Start()
    {
        anim = GetComponent<Animator>();

        hpModifier = 15;
        baseHP = 90 + (hpModifier * SetLevel());
        currentHP = baseHP;
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
            anim.SetBool("WarriorDead", true);
            Destroy(this.gameObject);
            
        }
        if (withinRange) //om player inom range
        {

        }
    }

    IEnumerator Timer()
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
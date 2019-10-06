using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior : Enemy
{
    bool withinRange = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        hpModifier = 15;
        baseHP = 90 + (hpModifier * SetLevel());
        currentHP = baseHP;
    }

    private void Update()
    {
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
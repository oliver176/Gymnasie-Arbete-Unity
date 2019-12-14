﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Archer : Enemy
{
    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    public GameObject Arrow;
    private GameObject Player;
    public Image healthBar;
    private Animator anim;
    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();

        hpModifier = 12;
        baseHP = 90 + (hpModifier * SetLevel());
        currentHP = baseHP;

        fireRate = 3;
        counter = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            healthBar.fillAmount = TakeDamage(10, currentHP, baseHP);
            currentHP -= 10;
        }

        isDead = DeadCheck(currentHP);

        if (isDead)
        {
            anim.SetBool("IsDead", true);
            StartCoroutine("DeathTimer");
        }

        counter -= Time.deltaTime;

        if (inRange)
        {
            if (counter < 0 && anim.GetBool("IsDead") == false)
            {
                Instantiate(Arrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                counter = fireRate;
            }
        }

        // If the input is moving the player right and the player is facing left...
        if (Player.transform.position.x > transform.position.x && !m_FacingRight && anim.GetBool("IsDead") == false)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Player.transform.position.x < transform.position.x && m_FacingRight && anim.GetBool("IsDead") == false)
        {
            // ... flip the player.
            Flip();
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //blir null om det inte har en polygon collider på sig.
        PolygonCollider2D polygonCollider2D = other.gameObject.GetComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
        PolygonCollider2D p_collider;
        p_collider = other.gameObject.GetComponent<PolygonCollider2D>();

        if (other.gameObject.tag == "MagicAttack")
        {
            float dmg = Random.Range(PlayerStats.minMagiDmg, PlayerStats.maxMagiDmg);
            Debug.Log("DAMAGE = " + dmg);
            Debug.Log("HP: " + currentHP);
            healthBar.fillAmount = TakeDamage(dmg, currentHP, baseHP);
            currentHP -= dmg;
        }
        else if (polygonCollider2D != null && p_collider.enabled)
        {
            float dmg = Random.Range(PlayerStats.minPhysDmg, PlayerStats.minPhysDmg);
            healthBar.fillAmount = TakeDamage(dmg, currentHP, baseHP);
            currentHP -= dmg;
        }
    }
    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //inom collidern som representerar range
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //inom collidern som representerar range
        {
            inRange = false;
        }
    }
}

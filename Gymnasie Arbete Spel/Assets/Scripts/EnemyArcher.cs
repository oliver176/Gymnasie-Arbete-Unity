using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    int currentHP;
    public float xpGain = 100;
    public int baseHP = 90;
    public int hpModifier = 12;

    public float dmgModifier = 0.008f;
    public float minDmg = 2000;
    public float maxDmg = 3500;

    public float fireRate;
    private float counter;

    int playerLevel;
    int enemyLevel;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
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

        // If the input is moving the player right and the player is facing left...
        if (Player.transform.position.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Player.transform.position.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            PlayerStats.XPGain(xpGain);
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
}

using UnityEngine;

public class Archer : Enemy
{

    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        xpGain = 100;
        baseHP = 90;
        hpModifier = 12;

        dmgModifier = 0.008f;
        minDmg = 2000;
        maxDmg = 3500;

        fireRate = 3;
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
        if (Player.transform.position.x > transform.position.x && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Player.transform.position.x < transform.position.x && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        if (currentHP <= 0)
        {
            //Destroy(gameObject);
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

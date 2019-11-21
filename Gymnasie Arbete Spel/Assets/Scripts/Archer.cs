using UnityEngine;
using UnityEngine.UI;

public class Archer : Enemy
{
    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    public GameObject Arrow;
    private GameObject Player;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

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
        Player p = other.gameObject.GetComponent<Player>();

        if (other.gameObject.GetComponent<Player>().GetType().IsSubclassOf(typeof(Player)))
        {
            if (true)
            {

            }
        }
    }
}

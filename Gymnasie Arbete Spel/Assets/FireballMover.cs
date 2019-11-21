using UnityEngine;

public class FireballMover : CharacterController2D
{
    public float projectileSpeed;
    private Vector2 direction;
    private bool facingRight;

    // Start is called before the first frame update
    private void Start()
    {
        if (m_FacingRight)
        {
            facingRight = true;
            Flip();
        }
        else if (!m_FacingRight)
        {
            facingRight = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (facingRight)
        {
            transform.Translate(Vector2.right * projectileSpeed);
        }
        else if (!facingRight)
        {
            transform.Translate(Vector2.left * projectileSpeed);
        }
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
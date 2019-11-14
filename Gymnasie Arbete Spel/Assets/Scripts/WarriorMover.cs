using UnityEngine;

public class WarriorMover : Warrior
{
    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform groundDetection;
    public Transform wallDetection;
    public GameObject Player;

    private SpriteRenderer sprite;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float direction = Player.transform.position.x - transform.position.x;

        if (anim.GetBool("WarriorDead") == false && anim.GetBool("WarriorAttackRange"))
        {
            if (direction < 0 && movingRight)
            {
                Flip();
            }
            else if (direction > 0 && !movingRight)
            {
                Flip();
            }
        }
        if (anim.GetBool("WarriorDead") == false && anim.GetBool("WarriorAttackRange") == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            RaycastHit2D wallInfoRight = Physics2D.Raycast(wallDetection.position, Vector2.right, distance);

            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }
    private void Flip()
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
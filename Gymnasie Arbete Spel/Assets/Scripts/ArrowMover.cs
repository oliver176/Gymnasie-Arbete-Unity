using System.Collections;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2D;
    public int thrust;
    private Vector3 playerPos;

    private Vector2 direction;

    bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerPos = player.transform.position;

        direction = (player.transform.position - transform.position).normalized ;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1000);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (!hasCollided)
        {
            rb2D.AddForce(direction * thrust * Time.smoothDeltaTime);
            //gameObject.transform.Translate(direction * thrust * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "World Collider")
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }

        hasCollided = true;

        rb2D.velocity = Vector2.zero;
        rb2D.angularVelocity = 0.0f;
        rb2D.isKinematic = false;

        StartCoroutine("DestroyTimer");
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}

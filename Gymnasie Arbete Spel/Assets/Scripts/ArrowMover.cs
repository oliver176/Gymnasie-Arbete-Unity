using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2D;
    public int thrust;
    private Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1000);*/
    }
    void FixedUpdate()
    {
        rb2D.AddForce((playerPos - transform.position).normalized * thrust * Time.smoothDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "World Collider" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

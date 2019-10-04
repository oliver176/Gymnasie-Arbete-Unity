using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : DamageDealer
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

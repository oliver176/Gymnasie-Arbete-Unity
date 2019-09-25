using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb2D;
    public int thrust;



    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb2D.AddForce((player.transform.position - transform.position).normalized * thrust * Time.smoothDeltaTime);
    }
}

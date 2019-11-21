using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerStats
{
    public GameObject Fireball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Hit();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CastFireball();
        }
    }

    void Hit()
    {
        Debug.Log("HAJAAA!!!");
    }

    void CastFireball()
    {
        Instantiate(Fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}

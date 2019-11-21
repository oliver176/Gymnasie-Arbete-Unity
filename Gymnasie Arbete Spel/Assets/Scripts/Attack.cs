using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerStats
{
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
            Cast();
        }
    }

    void Hit()
    {
        Debug.Log("HAJAAA!!!");
    }

    void Cast()
    {
        Debug.Log("HADOUKEN!!!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    bool withinRange = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (withinRange) //om player inom range
        {

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //inom collidern som representerar range
        {
            withinRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")  //när player lämnar collidern
        {
            withinRange = false;
        }
    }
}

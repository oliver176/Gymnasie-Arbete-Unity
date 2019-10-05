using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : HealthManager
{
    public Text hp;

    // Start is called before the first frame update
    void Start()
    {

        hp.text = "Health: " + playerCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "Health: " + playerCurrentHealth;
    }
}

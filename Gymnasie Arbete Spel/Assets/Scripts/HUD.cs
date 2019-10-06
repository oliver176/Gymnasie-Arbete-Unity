﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text displayText;
    float statToDisplay;
    int statInInt;
    public GameObject PlayerObject;
    public GameObject StatText;

    // Start is called before the first frame update
    void Start()
    {
        statInInt = Mathf.RoundToInt(statToDisplay);
        displayText.text = StatText.tag + statInInt;
    }

    // Update is called once per frame
    void Update()
    {
        if (StatText.name.Contains("Health"))
        {
            statToDisplay = Player.playerCurrentHealth;
        }
        if (StatText.name.Contains("Shield"))
        {
            statToDisplay = Player.playerCurrentShield;
        }

        statInInt = Mathf.RoundToInt(statToDisplay);
        if (statInInt <= 0 )
        {
            statInInt = 0;
        }
        displayText.text = StatText.tag + statInInt;
    }
}

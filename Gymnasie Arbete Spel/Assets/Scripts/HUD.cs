﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text displayText;
    float statToDisplay;
    int statInInt;
    string textToDisplay;
    public GameObject PlayerObject;
    public GameObject StatText;
    private string questText = "Kill 12 skeletons: {0}/12";

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
        if (StatText.name.Contains("Quest"))
        {
            textToDisplay = string.Format(questText, Player.killCount);
            Debug.Log(textToDisplay);
            displayText.text = StatText.tag + textToDisplay;
        }

        statInInt = Mathf.RoundToInt(statToDisplay);
        if (statInInt <= 0 )
        {
            statInInt = 0;
        }

        textToDisplay = statInInt.ToString();
        
        displayText.text = StatText.tag + textToDisplay;
    }
}

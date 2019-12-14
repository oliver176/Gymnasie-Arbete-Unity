using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text displayText;
    //float statToDisplay;
    //int statInInt;
    string textToDisplay;
    public GameObject StatText;
    string healthText = "Health: {0}";
    string shieldText = "Shield: {0}";
    string objectiveText = "Objective:\nKill 12 skeletons";
    string statusText = "Objective status:\n{0}/12";

    // Start is called before the first frame update
    void Start()
    {
        //statInInt = Mathf.RoundToInt(statToDisplay);
        //displayText.text = StatText.tag + statInInt;
    }

    // Update is called once per frame
    void Update()
    {
        if (StatText.name.Contains("Health"))
        {
            textToDisplay = String.Format(healthText, Mathf.RoundToInt(CheckPositive(Player.playerCurrentHealth)));
        }
        if (StatText.name.Contains("Shield"))
        {
            textToDisplay = String.Format(shieldText, Mathf.RoundToInt(CheckPositive(Player.playerCurrentShield)));
        }
        if (StatText.name.Contains("Quest"))
        {
            textToDisplay = objectiveText;
        }
        if (StatText.name.Contains("Status"))
        {
            textToDisplay = string.Format(statusText, Player.killCount);
        }

        //textToDisplay = statInInt.ToString();
        
        displayText.text = /*StatText.tag +*/ textToDisplay;
    }

    float CheckPositive(float statToCheck)
    {
        if (Mathf.RoundToInt(statToCheck) < 1)
        {
            return statToCheck = 0;
        }
        else return statToCheck;
    }
}

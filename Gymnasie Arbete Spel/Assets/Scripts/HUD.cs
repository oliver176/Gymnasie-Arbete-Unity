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
    static float currentTime = 600f;
    static float minute = 0;
    static float second = 0;
    //static float startingTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //statInInt = Mathf.RoundToInt(statToDisplay);
        //displayText.text = StatText.tag + statInInt;
        //currentTime = startingTime;
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
        if (StatText.name.Contains("Timer"))
        {
            currentTime -= 1 * Time.deltaTime;

            textToDisplay = GetTime();
        }

        //textToDisplay = statInInt.ToString();

        displayText.text = /*StatText.tag +*/ textToDisplay;
    }

    string GetTime()
    {
        string timerText = "{0}:{1}";

        minute = currentTime / 60;

        second = (minute - Mathf.Floor(minute)) * 60;

        minute = Mathf.Floor(minute);
        second = Mathf.Floor(second);

        Debug.Log("MINUTE " + minute);
        Debug.Log("SECOND " + second);

        timerText = String.Format(timerText, minute, second);

        Debug.Log("TIME " + timerText);

        return timerText;
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

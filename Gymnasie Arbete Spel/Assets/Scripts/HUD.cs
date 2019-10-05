using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text displayText;
    float statToDisplay;
    int statInInt;
    public GameObject Player;
    public GameObject StatText;

    // Start is called before the first frame update
    void Start()
    {
        HealthManager hpM = Player.GetComponent<HealthManager>();

        statInInt = Mathf.RoundToInt(statToDisplay);
        displayText.text = StatText.tag + statInInt;
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager hpM = Player.GetComponent<HealthManager>();

        if (StatText.name.Contains("Health"))
        {
            statToDisplay = hpM.playerCurrentHealth;
        }
        if (StatText.name.Contains("Shield"))
        {
            statToDisplay = hpM.playerCurrentShield;
        }

        statInInt = Mathf.RoundToInt(statToDisplay);

        displayText.text = StatText.tag + statInInt;
    }
}

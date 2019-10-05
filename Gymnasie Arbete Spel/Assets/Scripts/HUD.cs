using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text hp;
    int roundedHp;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        HealthManager hpM = Player.GetComponent<HealthManager>();
        roundedHp = Mathf.RoundToInt(hpM.playerCurrentHealth);
        hp.text = "Health: " + roundedHp;
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager hpM = Player.GetComponent<HealthManager>();
        roundedHp = Mathf.RoundToInt(hpM.playerCurrentHealth);
        if (roundedHp <= 0)
        {
            roundedHp = 0;
        }
        hp.text = "Health: " + roundedHp;
    }
}

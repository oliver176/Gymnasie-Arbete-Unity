using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : PlayerStats
{
    public static bool ButtonInfoIsEnabled = false;
    public GameObject ButtonInfoUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (ButtonInfoIsEnabled)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }

    private void Show()
    {
        ButtonInfoUI.SetActive(false);
        ButtonInfoIsEnabled = false;
    }

    private void Hide()
    {
        ButtonInfoUI.SetActive(true);
        ButtonInfoIsEnabled = true;
    }
}

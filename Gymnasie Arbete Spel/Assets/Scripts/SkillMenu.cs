using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public static bool skillMenuIsEnabled = false;
    public GameObject SkillMenuUI;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (skillMenuIsEnabled)
            {
                Resume();
            }
            else
            {
                EnableSkillMenu();
            }
        }
    }

    void Resume()
    {
        SkillMenuUI.SetActive(false);
        Time.timeScale = 1f;
        skillMenuIsEnabled = false;
    }

    void EnableSkillMenu()
    {
        SkillMenuUI.SetActive(true);
        Time.timeScale = 0f;
        skillMenuIsEnabled = true;
    }
}

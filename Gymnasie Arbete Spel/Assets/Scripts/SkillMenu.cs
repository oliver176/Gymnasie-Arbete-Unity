using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : PlayerStats
{
    public static bool skillMenuIsEnabled = false;
    public GameObject SkillMenuUI;
    public Button Magic1;

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = Magic1.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Button btn = Magic1.GetComponent<Button>();
        if (physSkillLevel >= 1)
        {
            btn.onClick.AddListener(TaskOnClick);
        }
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
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
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

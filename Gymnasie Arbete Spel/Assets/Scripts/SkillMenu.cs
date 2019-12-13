using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : PlayerStats
{
    public static bool skillMenuIsEnabled = false;
    public GameObject SkillMenuUI;
    public Button Magic1;
    public Button Magic2;
    public Button Magic3;
    public Button Physical1;
    public Button Physical2;
    public Button Physical3;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        /*Button btn_m1 = Magic1.GetComponent<Button>();
        Button btn_m2 = Magic1.GetComponent<Button>();
        Button btn_m3 = Magic1.GetComponent<Button>();
        Button btn_p1 = Magic1.GetComponent<Button>();
        Button btn_p2 = Magic1.GetComponent<Button>();
        Button btn_p3 = Magic1.GetComponent<Button>();

        if (physSkillLevel >= 2) //
        {
            btn_p1.onClick.AddListener(ActivatePhys1);
        }
        if (magiSkillLevel >= 2)
        {
            btn_m1.onClick.AddListener(ActivateMagi1);
        }*/

        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (skillMenuIsEnabled)
            {
                Resume();
            }
            else
            {
                EnableSkillMenu();
            }
        }*/
    }

    private void ActivateMagi1()
    {
        Debug.Log("You have clicked the button!");
    }
    private void ActivateMagi2()
    {
        Debug.Log("You have clicked the button!");
    }
    private void ActivateMagi3()
    {
        Debug.Log("You have clicked the button!");
    }
    private void ActivatePhys1()
    {

    }
    private void ActivatePhys2()
    {

    }
    private void ActivatePhys3()
    {

    }

    private void Resume()
    {
        SkillMenuUI.SetActive(false);
        Time.timeScale = 1f;
        skillMenuIsEnabled = false;
    }

    private void EnableSkillMenu()
    {
        SkillMenuUI.SetActive(true);
        Time.timeScale = 0f;
        skillMenuIsEnabled = true;
    }
}
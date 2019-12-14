using System.Collections;
using UnityEngine;

public class Player : CharacterController2D
{
    public static bool finished = false;
    public static bool hasClosed = false;
    public static int physSkillLevel = 0;
    public static int magiSkillLevel = 0;
    public static int killCount = 0;
    public static float minPhysDmg;
    public static float maxPhysDmg;
    public static float minMagiDmg;
    public static float maxMagiDmg;
    public static float physDmgModifier;
    public static float magiDmgModifier;
    public static float currentXP = 0;
    public static float xpToLevelUp;
    public static int xpModifierperLvl = 20;
    public static float playerMaxHealth;
    public static float playerMaxShield;
    public static float shieldRechargeDelay;
    public static float playerCurrentHealth;
    public static float playerCurrentShield;
    public static int level = 0;
    static bool gameTimerStarted = false;
    static float currentTime = 600f;

    // Start is called before the first frame update
    private void Start()
    {
        killCount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (!gameTimerStarted)
        {
            Debug.Log("STARTED");
            //StartCoroutine("GameTimer");
            gameTimerStarted = true;
        }

        if (killCount >= 12 || currentTime <= 0)
        {
            finished = true;
            Debug.Log("COMPLETE");
        }

        if (finished && !hasClosed)
        {
            ExitGame();
        }
    }

    private void ExitGame()
    {
        hasClosed = true;
        Application.OpenURL("https://forms.gle/AyeGZvXBFArXyJxB7");
        Application.Quit();
    }

    private IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(60);
        finished = true;
        Debug.Log("FINISHED");
    }
}
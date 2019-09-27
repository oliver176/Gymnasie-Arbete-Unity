using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    float xpToLevelUp;
    public static float currentXP = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void XPToLEvelUp()
    {
        if (level < 2)
        {
            xpToLevelUp = 100;
        }
        else
            xpToLevelUp += xpToLevelUp * 1.07f + (23 * (level - 1) + 1);
    }

    void LevelUpCheck()
    {
        if (currentXP == xpToLevelUp)
        {
            level++;
        }
    }

    public static void XPGain(float xp)
    {
        currentXP += xp;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
    }
}
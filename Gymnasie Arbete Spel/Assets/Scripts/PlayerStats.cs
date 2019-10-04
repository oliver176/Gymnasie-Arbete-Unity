using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public float xpToLevelUp;
    public float xpModifierperLvl;
    public static float currentXP = 0;

    // Start is called before the first frame update
    void Start()
    {
        XPToLevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
    }

    void XPToLevelUp()
    {
        xpToLevelUp += xpModifierperLvl * (level - 1);
        //xpToLevelUp = (xpToLevelUp * 1.07f) + (23 * (level - 1) + 1);
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
}
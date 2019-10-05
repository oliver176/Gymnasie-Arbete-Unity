using UnityEngine;

public class PlayerStats : Player
{
    public static float currentXP = 0;
    protected static float xpToLevelUp = 100;
    protected static int xpModifierperLvl = 20;
    protected static float playerMaxHealth;
    protected static float playerMaxShield;
    protected static float shieldRechargeDelay;
    public static float playerCurrentHealth;
    public static float playerCurrentShield;
    public static int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
    }

    void LevelUp()
    {
        level++;
        xpToLevelUp += xpModifierperLvl * (level - 1);
        playerCurrentHealth = playerMaxHealth;
        //xpToLevelUp = (xpToLevelUp * 1.07f) + (23 * (level - 1) + 1);
    }

    void LevelUpCheck()
    {
        if (currentXP == xpToLevelUp)
        {
            LevelUp();
        }
    }
}
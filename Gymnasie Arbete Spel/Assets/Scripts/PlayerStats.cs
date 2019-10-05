using UnityEngine;

public class PlayerStats : Player
{
    public static float currentXP = 0;
    protected int xpToLevelUp;
    protected int xpModifierperLvl;
    protected float playerMaxHealth;
    protected float playerMaxShield;
    protected float shieldRechargeDelay;
    public float playerCurrentHealth;
    public float playerCurrentShield;
    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
    }

    protected void SetUp()
    {
        playerMaxHealth = 100;
    }

    void LevelUp()
    {
        level++;
        xpToLevelUp += xpModifierperLvl * (level - 1);
        //xpToLevelUp = (xpToLevelUp * 1.07f) + (23 * (level - 1) + 1);
        playerMaxHealth += 10 * (level - 1);
    }

    void LevelUpCheck()
    {
        if (currentXP == xpToLevelUp)
        {
            LevelUp();
        }
    }
}
using UnityEngine;

public class PlayerStats : Player
{
    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
        physDmgModifier = 1;
        magiDmgModifier = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
        minPhysDmg = 20f * physDmgModifier;
        maxPhysDmg = 30f * physDmgModifier;
        minMagiDmg = 15f * magiDmgModifier;
        maxMagiDmg = 40f * magiDmgModifier;
        //Debug.Log("LEVEL = " + level);
    }

    void LevelUp()
    {
        level++;
        playerMaxHealth = 90 + (10 * level);
        Debug.Log("MAXHP = " + playerMaxHealth);
        xpToLevelUp = 100 + (xpModifierperLvl * (level - 1));
        Debug.Log("XPTOLEVEL = " + xpToLevelUp);
        Debug.Log("CURRENTXP = " + currentXP);
        playerCurrentHealth = playerMaxHealth;
        //xpToLevelUp = (xpToLevelUp * 1.07f) + (23 * (level - 1) + 1);
    }

    void LevelUpCheck()
    {
        if (currentXP >= xpToLevelUp)
        {
            LevelUp();
        }
    }
}
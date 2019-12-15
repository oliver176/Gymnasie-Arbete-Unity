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
        //LevelUpCheck();
        minPhysDmg = 17.5f * physDmgModifier;
        maxPhysDmg = 30f * physDmgModifier;
        minMagiDmg = 12.5f * magiDmgModifier;
        maxMagiDmg = 25f * magiDmgModifier;
    }

    void LevelUp()
    {
        //Application.OpenURL("http://unity3d.com/");
        level++;
        physSkillLevel++;
        magiSkillLevel++;
        playerMaxHealth = 90 + (10 * level);
        Debug.Log("MAXHP = " + playerMaxHealth);
        xpToLevelUp = 100 + (xpModifierperLvl * (level - 1));
        Debug.Log("XPTOLEVEL = " + xpToLevelUp);
        currentXP = 0;
        Debug.Log("CURRENTXP = " + currentXP);
        Debug.Log("LEVEL = " + level);
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
using UnityEngine;

public class PlayerStats : Player
{
    // Start is called before the first frame update
    void Start()
    {
        physDmgModifier = 1 * (physSkillLevel / level);
        magiDmgModifier = 1 * (magiSkillLevel / level);
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpCheck();
        minPhysDmg *= 20 * physDmgModifier;
        maxPhysDmg *= 30 * physDmgModifier;
        minMagiDmg *= 15 * magiDmgModifier;
        maxMagiDmg *= 40 * magiDmgModifier;
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
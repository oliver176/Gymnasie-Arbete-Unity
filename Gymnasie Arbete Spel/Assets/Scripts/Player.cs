using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int physSkillLevel;
    public static int magiSkillLevel;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

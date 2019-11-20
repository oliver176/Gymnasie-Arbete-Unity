using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected static int physSkillLevel;
    protected static int magiSkillLevel;
    protected static float minPhysDmg;
    protected static float maxPhysDmg;
    protected static float minMagiDmg;
    protected static float maxMagiDmg;
    protected static float physDmgModifier;
    protected static float magiDmgModifier;
    public static float currentXP = 0;
    protected static float xpToLevelUp = 100;
    protected static int xpModifierperLvl = 20;
    protected static float playerMaxHealth;
    protected static float playerMaxShield;
    protected static float shieldRechargeDelay;
    public static float playerCurrentHealth;
    public static float playerCurrentShield;
    public static int level = 0;

    public GameObject MagicBall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(MagicBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public float xpToLevelUp = 100;

    // Start is called before the first frame update
    void Start()
    {
        XPToLEvelUp();
        Debug.Log(xpToLevelUp);
    }

    void XPToLEvelUp()
    {
        if (level < 2)
        {
            xpToLevelUp = 100;
        }
        else
            xpToLevelUp = xpToLevelUp * 1.07f + (23 * (level - 1) + 1);
    }

    void LevelUp()
    {
        level++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
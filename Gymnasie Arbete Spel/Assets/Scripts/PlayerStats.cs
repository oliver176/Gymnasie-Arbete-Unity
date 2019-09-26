using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 0;
    public int xpToLevelUp = 100;

    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
        Debug.Log(level);
    }

    void XPToLEvelUp()
    {
        //xpToLevelUp 
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
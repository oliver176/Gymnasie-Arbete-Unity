using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Archer
{
    // Start is called before the first frame update
    void Start()
    {
        dmgModifier = 0.008f;
        minDmg = 2000;
        maxDmg = 3500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

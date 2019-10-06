using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float minDmg;
    public float maxDmg;
    public float dmgModifier;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    public int SetLevel()
    {
        return Player.level;
    }

    protected void XpReward(float xp)
    {
        Player.currentXP += xp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

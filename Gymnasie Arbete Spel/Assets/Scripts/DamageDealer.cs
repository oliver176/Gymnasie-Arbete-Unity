using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float minDmg;
    public float maxDmg;
    public float dmgModifier;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    public int SetLevel()
    {
        PlayerStats playerStats = Player.GetComponent<PlayerStats>();

        return playerStats.level;
    }

    protected void XpReward(float xp)
    {
        PlayerStats.currentXP += xp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

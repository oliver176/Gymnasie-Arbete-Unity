using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float minDmg;
    public float maxDmg;
    public float dmgModifier;
    public int level;
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

    protected void Scale()
    {
        dmgModifier *= level / 2;
        minDmg *= dmgModifier;
        maxDmg *= dmgModifier;
    }

    public float Damage(int level, DamageDealer type)
    {
        return Random.Range(type.minDmg * level * type.dmgModifier, type.maxDmg * level * type.dmgModifier);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

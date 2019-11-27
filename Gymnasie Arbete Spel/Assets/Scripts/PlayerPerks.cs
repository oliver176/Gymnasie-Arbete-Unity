using UnityEngine;

public class PlayerPerks : MonoBehaviour
{
    static bool PhysPerkIITaken = false;
    static bool PhysPerkIIITaken = false;
    static bool PhysPerkIVTaken = false;
    static bool MagiPerkIITaken = false;
    static bool MagiPerkIIITaken = false;
    static bool MagiPerkIVTaken = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    static float PhysPerkII()
    {
        if (PhysPerkIITaken)
        {
            return 1.2f;
        }
        else return 1f;
    }

    static float PhysPerkIII()
    {
        if (PhysPerkIIITaken)
        {
            return 1.2f;
        }
        else return 1f;
    }

    static float PhysPerkIV()
    {
        if (PhysPerkIVTaken)
        {
            return 2f;
        }
        else return 1f;
    }

    static float MagiPerkII()
    {
        if (MagiPerkIITaken)
        {
            return 1.2f;
        }
        else return 1f;
    }

    static int MagiPerkIII()
    {
        if (MagiPerkIIITaken)
        {
            return 1;
        }
        else return 0;
    }

    static int MagiPerkIV()
    {
        if (MagiPerkIVTaken)
        {
            return 2;
        }
        else return 0;
    }
}

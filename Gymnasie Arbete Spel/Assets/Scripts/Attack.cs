using System.Collections;
using UnityEngine;

public class Attack : PlayerStats
{
    public GameObject Fireball;
    private Animator anim;
    private float castCooldown;
    private float magiCounter;
    private float hitCooldown;
    private float physCounter;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        magiCounter -= Time.deltaTime;
        physCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (physCounter <= 0)
            {
                SwordAttack1();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (magiCounter <= 0)
            {
                CastFireball();
            }
        }
    }

    private IEnumerator CastTimer()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(Fireball, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
    }

    private void SwordAttack1()
    {
        anim.SetTrigger("PlayerSwordAttack1");
        hitCooldown = 0.75f;
        physCounter = hitCooldown;
    }

    private void CastFireball()
    {
        anim.SetTrigger("PlayerCast");
        StartCoroutine("CastTimer");
        castCooldown = 0.75f;
        magiCounter = castCooldown;
    }
}
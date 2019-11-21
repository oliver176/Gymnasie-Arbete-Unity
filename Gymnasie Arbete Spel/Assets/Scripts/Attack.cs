using System.Collections;
using UnityEngine;

public class Attack : PlayerStats
{
    public GameObject Fireball;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Hit();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CastFireball();
        }
    }

    private IEnumerator CastTimer()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(Fireball, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
    }

    private void Hit()
    {
        Debug.Log("HAJAAA!!!");
    }

    private void CastFireball()
    {
        anim.SetTrigger("PlayerCast");
        StartCoroutine("CastTimer");
    }
}
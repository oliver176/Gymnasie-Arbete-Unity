using UnityEngine;

public class FireballMover : MonoBehaviour
{
    public float projectileSpeed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * projectileSpeed);
    }
}
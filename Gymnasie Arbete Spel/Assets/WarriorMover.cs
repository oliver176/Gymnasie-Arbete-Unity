using UnityEngine;

public class WarriorMover : MonoBehaviour
{
    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform wallDetectionRight;
    public Transform wallDetectionLeft;
    public Transform groundDetection;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D wallInfoRight = Physics2D.Raycast(wallDetectionRight.position, Vector2.right, distance);
        RaycastHit2D wallInfoLeft = Physics2D.Raycast(wallDetectionLeft.position, Vector2.left, distance);

        if (wallInfoRight.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }

        /*        if (groundInfo.collider == false)
                {
                    if (movingRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }*/
    }
}
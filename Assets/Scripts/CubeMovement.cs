using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the cube moves
    public float moveDistance = 5f; // Distance the cube moves left and right

    private Vector3 originalPosition;
    private bool movingRight = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= originalPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= originalPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}

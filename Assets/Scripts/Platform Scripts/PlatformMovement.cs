using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool isHorizontalPlatform;
    [SerializeField] private bool isVerticalPlatform;

    private bool isMovingRight = true;
    private bool isMovingUp = true;

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (isHorizontalPlatform)
        {
            if (isMovingRight)
            {
                Move(Vector2.right);
            }
            else
            {
                Move(Vector2.left);
            }
        }
        if (isVerticalPlatform)
        {
            if (isMovingUp)
            {
                Move(Vector2.up);
            }
            else
            {
                Move(Vector2.down);
            }
        }
    }

    public void ChangeDirection()
    {
        if (isHorizontalPlatform)
        {
            isMovingRight = !isMovingRight;
        }
        if (isVerticalPlatform)
        {
            isMovingUp = !isMovingUp;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementLimiter : MonoBehaviour
{
    [SerializeField] private PlatformMovement platformMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingPlatform"))
        {
            platformMovement.ChangeDirection();
        }
    }
}

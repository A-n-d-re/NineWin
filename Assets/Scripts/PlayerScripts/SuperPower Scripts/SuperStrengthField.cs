using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStrengthField : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DestructibleObstacle"))
        {
            Destroy(collision.gameObject);
        }
    }
}

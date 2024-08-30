using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private bool canPlayerTakeDamage = true;

    private void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (canPlayerTakeDamage)
            {
                canPlayerTakeDamage = false;

                playerHealth.CanTakeDamage(canPlayerTakeDamage);

                Debug.Log("Collision");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!canPlayerTakeDamage)
            {
                canPlayerTakeDamage = true;

                playerHealth.CanTakeDamage(canPlayerTakeDamage);

                Debug.Log("Exit");
            }
        }
    }
}

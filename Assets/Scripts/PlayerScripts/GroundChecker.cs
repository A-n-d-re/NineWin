using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == (LayerMask.NameToLayer("Ground"))) || (collision.gameObject.layer == (LayerMask.NameToLayer("Obstacle"))))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == (LayerMask.NameToLayer("Ground"))) || (collision.gameObject.layer == (LayerMask.NameToLayer("Obstacle"))))
        {
            isGrounded = false;
        }
    }
}

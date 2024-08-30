using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private GroundChecker groundChecker;
    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private float horizontal;

    private bool isMovingLeft;
    private bool isMovingRight;

    void Start()
    {
        groundChecker = GetComponentInChildren<GroundChecker>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (isMovingRight)
        {
            horizontal = 1;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (isMovingLeft)
        {
            horizontal = -1;

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            horizontal = 0;
        }
    }

    private void Move()
    {
        playerRigidbody.velocity = new Vector2(speed * horizontal, playerRigidbody.velocity.y);
    }

    public void Jump()
    {
        if (groundChecker.isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnLeftButtonDown()
    {
        isMovingLeft = true;

        animator.SetBool("isWalking", true);
    }

    public void OnLeftButtonUp()
    {
        isMovingLeft = false;

        animator.SetBool("isWalking", false);
    }

    public void OnRightButtonDown()
    {
        isMovingRight = true;

        animator.SetBool("isWalking", true);
    }

    public void OnRightButtonUp()
    {
        isMovingRight = false;

        animator.SetBool("isWalking", false);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float distanceToDetectPlayer;
    [SerializeField] private float speed;

    private EnemyAttackController enemyAttackController;
    private GameObject player;
    private Animator animator;

    private float enemyAndPlayerDistance;

    private void Start()
    {
        enemyAttackController = GetComponent<EnemyAttackController>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckDistance();

        LookAtPlayer();

        GoToPlayer();
    }

    private void GoToPlayer()
    {
        if (enemyAndPlayerDistance <= distanceToDetectPlayer && enemyAttackController.isAttacking == false)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void CheckDistance()
    {
        enemyAndPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
    }
}

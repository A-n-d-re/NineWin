using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public bool isAttacking { get; private set; }

    [SerializeField] private float damage;
    [SerializeField] private float distanceToAttackPlayer;
    [SerializeField] private float attackCooldown = 0.5f;

    private Animator animator;
    private GameObject player;
    private PlayerHealth playerHealth;

    private float enemyAndPlayerDistance;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckDistance();

        if (enemyAndPlayerDistance <= distanceToAttackPlayer)
        {
            isAttacking = true;

            Attack();
        }
        else
        {
            isAttacking = false;
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            canAttack = false;

            animator.SetTrigger("isAttacking");

            AudioManager.Instance.PlaySound("PunchSound");

            playerHealth.TakeDamage(damage);

            StartCoroutine(WaitToAttackAgain());
        }
    }

    private IEnumerator WaitToAttackAgain()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }


    private void CheckDistance()
    {
        enemyAndPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
    }
}

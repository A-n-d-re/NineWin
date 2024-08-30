using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private float attackCooldown = 0.5f;

    private EnemyDetector enemyDetector;
    private GroundChecker groundChecker;
    private PlayerMovement playerMovement;
    private Animator animator;

    private bool canAttack = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        enemyDetector = GetComponentInChildren<EnemyDetector>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void Update()
    {
        if (canAttack && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && groundChecker.isGrounded && !IsPointerOverUI(Input.GetTouch(0).fingerId))
        {
            canAttack = false;

            animator.SetTrigger("isAttacking");

            AudioManager.Instance.PlaySound("PunchSound");

            StartCoroutine(PerformAttack());
        }
    }

    private bool IsPointerOverUI(int fingerId)
    {
        return EventSystem.current.IsPointerOverGameObject(fingerId);
    }

    private IEnumerator PerformAttack()
    {
        if (enemyDetector.EnemyHealth != null)
        {
            enemyDetector.EnemyHealth.TakeDamage(damage);
        }

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}



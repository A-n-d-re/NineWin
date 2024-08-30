using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float damageEffectDuration = 0.1f;
    private float currentHealth;

    [Header("For Achievement Registration")]
    [SerializeField] private bool isBandit;
    [SerializeField] private bool isMonster;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        spriteRenderer.color = Color.red;

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(AfterDamage());
    }

    private void Die()
    {
        if (isBandit)
        {
            AchievementManager.Instance.KillBandit();
        }
        if (isMonster)
        {
            AchievementManager.Instance.KillMonster();
        }

        Destroy(gameObject);
    }

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(damageEffectDuration);

        spriteRenderer.color = Color.white;
    }
}

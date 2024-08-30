using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [Header("UI Settings")]
    [SerializeField] private float damageEffectDuration = 0.1f;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject gameOverCanvas;
    private SpriteRenderer spriteRenderer;

    public bool canGetDamage = true;

    private void Start()
    {
        currentHealth = maxHealth;

        UpdateHealthBar();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (canGetDamage)
        {
            currentHealth -= damage;

            spriteRenderer.color = Color.red;

            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }

            StartCoroutine(AfterDamage());
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void Die()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(damageEffectDuration);

        spriteRenderer.color = Color.white;
    }

    public void CanTakeDamage(bool value)
    {
        canGetDamage = value;
    }
}


using System.Collections;
using UnityEngine;
using TMPro;

public class SuperPowerActivator : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private TextMeshProUGUI dashTimer;
    [SerializeField] private string dashingLayerName;
    private int lastLayer;

    [Header("Shield Settings")]
    [SerializeField] private GameObject shield;
    [SerializeField] private float shieldDuration;
    [SerializeField] private TextMeshProUGUI shieldTimer;

    [Header("Super Strength Settings")]
    [SerializeField] private GameObject superStrengthField;
    [SerializeField] private float superStrengthDuration;
    [SerializeField] private TextMeshProUGUI superStrengthTimer;

    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ActivateDash()
    {
        StartCoroutine(PerformDash(dashDuration));
        animator.SetBool("isDashing", true);

        AudioManager.Instance.PlaySound("DashSound");

        lastLayer = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer(dashingLayerName);
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
        StartCoroutine(WaitToDeactivateAbility(shieldDuration, DeactivateShield, shieldTimer));

        AudioManager.Instance.PlaySound("ShieldSound");
    }

    public void ActivateSuperStrength()
    {
        superStrengthField.SetActive(true);
        StartCoroutine(WaitToDeactivateAbility(superStrengthDuration, DeactivateSuperStrengthField, superStrengthTimer));

        AudioManager.Instance.PlaySound("StrengthSound");
    }

    private IEnumerator PerformDash(float duration)
    {
        playerMovement.enabled = false;
        float direction = transform.rotation.y == 0 ? 1 : -1;

        playerRigidbody.velocity = new Vector2(direction * dashSpeed, playerRigidbody.velocity.y);

        yield return StartCoroutine(UpdateTimer(dashTimer, duration));

        animator.SetBool("isDashing", false);
        gameObject.layer = lastLayer;
        playerMovement.enabled = true;
        playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
    }

    private IEnumerator WaitToDeactivateAbility(float duration, System.Action deactivateAction, TextMeshProUGUI timerText)
    {
        yield return StartCoroutine(UpdateTimer(timerText, duration));
        deactivateAction?.Invoke();
    }

    private IEnumerator UpdateTimer(TextMeshProUGUI timerText, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = Mathf.Max(duration - elapsedTime, 0).ToString("F1");
            yield return null;
        }

        timerText.text = "0.0";
    }

    private void DeactivateShield()
    {
        shield.SetActive(false);
    }

    private void DeactivateSuperStrengthField()
    {
        superStrengthField.SetActive(false);
    }
}


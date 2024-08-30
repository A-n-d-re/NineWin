using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] private Image superPowerBar;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void DeactivateButton(float duration)
    {
        button.interactable = false;
        superPowerBar.fillAmount = 0;

        StartCoroutine(WaitToActivateButtonAgain(duration));
    }

    private IEnumerator WaitToActivateButtonAgain(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            superPowerBar.fillAmount = elapsedTime / duration;
            yield return null;
        }

        superPowerBar.fillAmount = 1;
        button.interactable = true;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementUIManager : MonoBehaviour
{
    [Header("Achievements Progress Text")]
    public TextMeshProUGUI coinsAchievementText;
    public TextMeshProUGUI banditsAchievementText;
    public TextMeshProUGUI monstersAchievementText;
    public TextMeshProUGUI gemsAchievementText;

    [Header("Completed Achievements Check Marks")]
    public Image coinsAchievementCheck;
    public Image banditsAchievementCheck;
    public Image monstersAchievementCheck;
    public Image gemsAchievementCheck;

    [Header("Achievements Goals")]
    [SerializeField] private int coinsTarget = 15;
    [SerializeField] private int banditsTarget = 15;
    [SerializeField] private int monstersTarget = 10;
    [SerializeField] private int gemsTarget = 10;

    private void Start()
    {
        UpdateAchievementsUI();
    }

    private void UpdateAchievementsUI()
    {
        var achievementManager = AchievementManager.Instance;

        if (achievementManager != null)
        {
            coinsAchievementText.text = $"{(PlayerPrefs.GetInt("CoinsCollected") / (float)coinsTarget) * 100:0}%";
            banditsAchievementText.text = $"{(PlayerPrefs.GetInt("BanditsKilled") / (float)banditsTarget) * 100:0}%";
            monstersAchievementText.text = $"{(PlayerPrefs.GetInt("MonstersKilled") / (float)monstersTarget) * 100:0}%";
            gemsAchievementText.text = $"{(PlayerPrefs.GetInt("GemsCollected") / (float)gemsTarget) * 100:0}%";

            coinsAchievementCheck.gameObject.SetActive(PlayerPrefs.GetInt("CoinsCollected") >= coinsTarget);
            coinsAchievementText.gameObject.SetActive(PlayerPrefs.GetInt("CoinsCollected") < coinsTarget);

            banditsAchievementCheck.gameObject.SetActive(PlayerPrefs.GetInt("BanditsKilled") >= banditsTarget);
            banditsAchievementText.gameObject.SetActive(PlayerPrefs.GetInt("BanditsKilled") < banditsTarget);

            monstersAchievementCheck.gameObject.SetActive(PlayerPrefs.GetInt("MonstersKilled") >= monstersTarget);
            monstersAchievementText.gameObject.SetActive(PlayerPrefs.GetInt("MonstersKilled") < monstersTarget);

            gemsAchievementCheck.gameObject.SetActive(PlayerPrefs.GetInt("GemsCollected") >= gemsTarget);
            gemsAchievementText.gameObject.SetActive(PlayerPrefs.GetInt("GemsCollected") < gemsTarget);

        }
        else
        {
            Debug.LogWarning("AchievementManager не найден!");
        }
    }
}


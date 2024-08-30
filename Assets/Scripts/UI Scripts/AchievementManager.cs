using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public int CoinsCollected { get; private set; }
    public int BanditsKilled { get; private set; }
    public int MonstersKilled { get; private set; }
    public int GemsCollected { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAchievements();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoin()
    {
        CoinsCollected++;
    }

    public void KillBandit()
    {
        BanditsKilled++;
    }

    public void KillMonster()
    {
        MonstersKilled++;
    }

    public void CollectGem()
    {
        GemsCollected++;
    }

    public void SaveAchievementsProgress()
    {
        PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);
        PlayerPrefs.SetInt("BanditsKilled", BanditsKilled);
        PlayerPrefs.SetInt("MonstersKilled", MonstersKilled);
        PlayerPrefs.SetInt("GemsCollected", GemsCollected);
        PlayerPrefs.Save();
    }

    private void LoadAchievements()
    {
        CoinsCollected = PlayerPrefs.GetInt("CoinsCollected");
        BanditsKilled = PlayerPrefs.GetInt("BanditsKilled");
        MonstersKilled = PlayerPrefs.GetInt("MonstersKilled");
        GemsCollected = PlayerPrefs.GetInt("GemsCollected");
    }
}


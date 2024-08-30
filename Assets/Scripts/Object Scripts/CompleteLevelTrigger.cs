using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject completedGameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AchievementManager.Instance.SaveAchievementsProgress();

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            int levelToUnlock = PlayerPrefs.GetInt("LevelToUnlock");

            if (levelToUnlock < currentSceneIndex)
            {
                PlayerPrefs.SetInt("LevelToUnlock", currentSceneIndex);
                PlayerPrefs.Save();
            }

            completedGameCanvas.SetActive(true);

            Time.timeScale = 0;
        }
    }
}

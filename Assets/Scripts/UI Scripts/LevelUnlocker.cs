using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        int levelToUnlock = PlayerPrefs.GetInt("LevelToUnlock");

        for (int i = 0; i <= levelToUnlock; i++)
        {
            if (levelButtons[i].interactable == false)
            {
                levelButtons[i].interactable = true;
            }
        }
    }
}
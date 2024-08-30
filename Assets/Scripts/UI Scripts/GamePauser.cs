using UnityEngine;

public class GamePauser : MonoBehaviour
{
    public void PauseTheGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1f;
    }
}
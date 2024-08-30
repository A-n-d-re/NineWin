using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreAmountText;
    [SerializeField] private TextMeshProUGUI gameOverScoreAmountText;
    [SerializeField] private TextMeshProUGUI completedGameScoreAmountText;

    private int scoreAmount;

    private void Start()
    {
        scoreAmountText.text = scoreAmount.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        scoreAmount += scoreToAdd;

        scoreAmountText.text = scoreAmount.ToString();
        gameOverScoreAmountText.text = scoreAmount.ToString();
        completedGameScoreAmountText.text = scoreAmount.ToString();
    }
}

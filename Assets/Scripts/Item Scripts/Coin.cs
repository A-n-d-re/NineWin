using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int scoreToAdd;

    [Header("For Achievement Registration")]
    [SerializeField] private bool isCoin;
    [SerializeField] private bool isGem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ScoreController>().AddScore(scoreToAdd);

            AudioManager.Instance.PlaySound("CollectSound");

            if (isCoin)
            {
                AchievementManager.Instance.CollectCoin();
            }
            if (isGem)
            {
                AchievementManager.Instance.CollectGem();
            }

            Destroy(gameObject);
        }
    }
}

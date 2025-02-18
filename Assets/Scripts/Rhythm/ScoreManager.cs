using UnityEngine;
using TMPro; // 确保使用 TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // 使用 TMP_Text 兼容 TextMeshPro
    private int score = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        Debug.Log("Score updated: " + score); // 调试信息
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("Score Text is not assigned in ScoreManager!");
        }
    }

    public int GetScore()
    {
        return score;
    }
}

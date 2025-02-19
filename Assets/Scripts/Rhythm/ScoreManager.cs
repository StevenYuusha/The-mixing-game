using UnityEngine;
using TMPro; // 确保你有导入 TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // 这是单例的关键
    public TextMeshProUGUI scoreText; // 在 Inspector 里绑定 UI 文本
    private int score = 0;

    void Awake()
    {
        // 确保单例存在，防止多个 ScoreManager 导致冲突
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText UI is not assigned in ScoreManager!");
        }
    }
}

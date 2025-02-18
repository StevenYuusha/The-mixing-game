using UnityEngine;
using TMPro; // ȷ��ʹ�� TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // ʹ�� TMP_Text ���� TextMeshPro
    private int score = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
        Debug.Log("Score updated: " + score); // ������Ϣ
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

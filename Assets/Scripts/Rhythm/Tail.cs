using UnityEngine;

public class Tail : MonoBehaviour
{
    public float lifetime = 3.0f; // 音符存活时间
    private bool isHit = false;

    void Start()
    {
        // 超时后自动销毁
        Invoke(nameof(AutoDestroy), lifetime);
    }

    public void Hit()
    {
        if (isHit) return; // 防止重复击打
        isHit = true;

        UnityEngine.Debug.Log("Tail was hit!");

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(100);
        }
        else
        {
            UnityEngine.Debug.LogError("ScoreManager not found!");
        }

        Destroy(gameObject); // 删除 Tail
    }

    void AutoDestroy()
    {
        if (!isHit)
        {
            UnityEngine.Debug.Log("Tail expired and was not hit.");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            UnityEngine.Debug.Log("PlayerHand touched Tail!");
            Hit();
        }
    }
}

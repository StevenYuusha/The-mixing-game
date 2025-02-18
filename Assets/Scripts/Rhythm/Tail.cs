using UnityEngine;

public class Tail : MonoBehaviour
{
    public float lifetime = 3.0f; // �������ʱ��
    private bool isHit = false;

    void Start()
    {
        // ��ʱ���Զ�����
        Invoke(nameof(AutoDestroy), lifetime);
    }

    public void Hit()
    {
        if (isHit) return; // ��ֹ�ظ�����
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

        Destroy(gameObject); // ɾ�� Tail
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

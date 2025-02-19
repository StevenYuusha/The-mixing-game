using UnityEngine;

public class Tail : MonoBehaviour
{
    public float lifetime = 3f; // 持续时间
    private bool isHit = false;

    void Start()
    {
        Invoke(nameof(Expire), lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hand touch");
        //if (isHit) return;
        
        if (collision.gameObject.CompareTag("PlayerHand")) // 物理手部碰撞
        {
            isHit = true;
            Debug.Log("Tail was hit by physical hands!");
            ScoreManager.Instance.AddScore(10);
            Destroy(gameObject);
            isHit = false;
        }
    }

    void Expire()
    {
        if (!isHit)
        {
            Debug.Log("Tail expired and was not hit.");
        }
        Destroy(gameObject);
    }
}

using UnityEngine;
using Leap.PhysicalHands;

public class Tail : MonoBehaviour
{
    public float lifetime = 3f; // 持续时间
    private bool isHit = false;
    private PhysicalHandsManager handsManager; // 手动获取 HandsManager

    void Start()
    {
        Invoke(nameof(Expire), lifetime);

        // 手动查找 HandsManager
        handsManager = FindObjectOfType<PhysicalHandsManager>();

        if (handsManager != null)
        {
            handsManager.onContact.AddListener(OnHandContact);
        }
        else
        {
            Debug.LogError("PhysicalHandsManager 未找到！请确保它已挂载到场景中！");
        }
    }

    void OnHandContact(ContactHand contacthand, Rigidbody rbody)
    {
        if (isHit) return;
        if (rbody.gameObject == gameObject) // 确保触碰的是 Tail
        {
            isHit = true;
            Debug.Log("Tail 被手触碰到了！");
            ScoreManager.Instance.AddScore(10); // 计分
            Destroy(gameObject);
        }
    }

    void Expire()
    {
        if (!isHit) 
        {
            Debug.Log("Tail 超时消失。");
        }
        Destroy(gameObject);
    }
}

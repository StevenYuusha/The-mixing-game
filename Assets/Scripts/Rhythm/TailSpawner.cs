using UnityEngine;
using System.Collections;

public class TailSpawner : MonoBehaviour
{
    public GameObject tailPrefab; // 尾巴预制体
    public Transform[] spawnPoints; // 生成点数组
    public AudioSource musicSource; // 音乐播放器
    public float[] tailTimings; // 音符出现时间点

    private int nextTailIndex = 0;

    void Start()
    {
        if (musicSource == null)
        {
            UnityEngine.Debug.LogError("TailSpawner: Music Source is not assigned!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            UnityEngine.Debug.LogError("TailSpawner: No spawn points assigned!");
            return;
        }

        if (tailTimings == null || tailTimings.Length == 0)
        {
            UnityEngine.Debug.LogError("TailSpawner: No tail timings assigned!");
            return;
        }

        StartCoroutine(SpawnTailsWithMusic());
    }

    IEnumerator SpawnTailsWithMusic()
    {
        while (nextTailIndex < tailTimings.Length)
        {
            float waitTime = tailTimings[nextTailIndex] - musicSource.time;

            if (waitTime > 0)
            {
                yield return new WaitForSeconds(waitTime);
            }

            SpawnTail();
            nextTailIndex++;
        }
    }

    void SpawnTail()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            UnityEngine.Debug.LogError("SpawnTail: No spawn points assigned!");
            return;
        }

        if (nextTailIndex >= tailTimings.Length)
        {
            UnityEngine.Debug.LogError($"SpawnTail: nextTailIndex ({nextTailIndex}) is out of range! tailTimings.Length = {tailTimings.Length}");
            return;
        }

        int index = UnityEngine.Random.Range(0, spawnPoints.Length);

       
        Instantiate(tailPrefab, spawnPoints[index].position, tailPrefab.transform.rotation);

        UnityEngine.Debug.Log($"Spawned Tail at index {index}, nextTailIndex = {nextTailIndex}");
    }
}

using UnityEngine;
using System.Collections.Generic;

public class BeatDetector : MonoBehaviour
{
    public AudioSource musicSource; // 背景音乐
    public float sensitivity = 0.5f; // 灵敏度（可调）
    public float minBeatInterval = 0.3f; // 最小鼓点间隔，防止连续误判

    private float lastBeatTime = 0f;
    private List<float> detectedBeats = new List<float>();

    void Update()
    {
        if (!musicSource || !musicSource.isPlaying) return;

        float[] spectrum = new float[256];
        musicSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float sum = 0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            sum += spectrum[i];
        }

        if (sum > sensitivity && Time.time - lastBeatTime > minBeatInterval)
        {
            lastBeatTime = Time.time;
            float beatTime = musicSource.time; // 当前音乐时间
            detectedBeats.Add(beatTime);
            Debug.Log($"🎵 Detected Beat at: {beatTime}");
        }
    }

    public List<float> GetDetectedBeats()
    {
        // 返回检测到的鼓点数据拷贝
        return new List<float>(detectedBeats);
    }
}

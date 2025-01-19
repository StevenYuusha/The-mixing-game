using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject StreamPrefab = null;

    private bool isPouring = false;
    private Stream currentStream = null;

    private void Update()
    {
        bool pourCheck = CalculatePourAngel() < pourThreshold;

        if(isPouring != pourCheck)
        {
            isPouring = pourCheck;
            if (isPouring)
            {
                StartPour();
            } else 
            {
                EndPour();
            }
        }

    }

    private void StartPour()
    {
        print("start");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        print("end");
        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngel()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(StreamPrefab, origin.position, Quaternion.identity, transform);

        return streamObject.GetComponent<Stream>();

    }
}
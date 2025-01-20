using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class TimerCheck : MonoBehaviour
{
    public Timer timer; // Reference to the timer
    public BowlDetector bowlDetector; // Reference to the bowl detection script

     public TextMeshProUGUI FinishText;

    private void Start()
    {
        // Assuming the timer's onTimerEnd event is used to trigger the check
        if (timer != null)
        {
            timer.onTimerEnd.AddListener(CheckRequirements);
        }
    }

    private void CheckRequirements()
    {
        // Check if ice cube is in the bowl and it's filled with sake
        if (bowlDetector.IsIceCubeInBowl() && bowlDetector.IsSakeInBowl())
        {
            if (bowlDetector.GetFillLevel() >= bowlDetector.maxFill)
            {
                FinishText.text = "Great success! Ice cube is in the bowl and the bowl is full of sake.";
                FinishText.color = Color.green;
                Debug.Log("Great success! Ice cube is in the bowl and the bowl is full of sake.");
            }
            else
            {
                Debug.Log("Requirements met! Ice cube is in the bowl and the bowl is " + bowlDetector.GetFillLevel() + "% full.");
                FinishText.color = Color.gray;
                FinishText.text = "Requirements met! Ice cube is in the bowl and the bowl is " + bowlDetector.GetFillLevel() + "% full.";
            }

        }
        else
        {
            if (!bowlDetector.IsIceCubeInBowl() && !bowlDetector.IsSakeInBowl())
            {
                Debug.Log("Critical fail. Nothing is in the bowl.");
                FinishText.color = Color.red;
                FinishText.text = "Critical fail. Nothing is in the bowl.";

            } else if (!bowlDetector.IsIceCubeInBowl())
            {
                Debug.Log("Fail. Missing Ice cube.");
                FinishText.color = Color.red;
                FinishText.text = "Fail. Missing Ice cube.";
            } else if (!bowlDetector.IsSakeInBowl())
            {
                Debug.Log("Fail. Missing sake.");
                FinishText.color = Color.red;
                FinishText.text = "Fail. Missing sake.";
            }

        }
    }
}

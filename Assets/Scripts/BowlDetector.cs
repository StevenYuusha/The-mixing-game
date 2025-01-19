using UnityEngine;

public class BowlDetector : MonoBehaviour
{
    public float maxFill = 100f; // Maximum fill level
    public float fillRate = 1f;  // Amount added per particle collision
    public Transform liquidFill; // Reference to liquid fill object for visualization

    private float currentFill = 0f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Liquid")) // Ensure the pouring stream has the correct tag
        {
            // Increment fill level by a fixed amount
            currentFill += fillRate;
            currentFill = Mathf.Clamp(currentFill, 0, maxFill); // Clamp within range
            UpdateFillVisual(); // Update the liquid level visualization
        }
    }

    private void UpdateFillVisual()
    {
        if (liquidFill != null)
        {
            Vector3 scale = liquidFill.localScale;
            scale.y = Mathf.Lerp(0, 1, currentFill / maxFill); // Map fill to a 0-1 range
            liquidFill.localScale = scale; // Update scale to represent fill level
        }
    }

    public float GetFillLevel()
    {
        return currentFill; // Return current fill level for game logic
    }
}

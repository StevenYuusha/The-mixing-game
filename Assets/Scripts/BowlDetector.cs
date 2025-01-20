using UnityEngine;

public class BowlDetector : MonoBehaviour
{
    public float maxFill = 100f; // Maximum fill level
    public float fillRate = 1f;  // Amount added per particle collision
    public Transform liquidFill; // Reference to liquid fill object for visualization (can be ignored for now)
    public bool hasIceCube = false; // To check if an ice cube is in contact with the bowl

    private float currentFill = 0f;

    // This method is called when an object first collides with the bowl
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ice cube is touching the bowl
        if (collision.gameObject.CompareTag("IceCube"))
        {
            hasIceCube = true; // Ice cube has touched the bowl
            Debug.Log("Ice cube has touched the bowl.");
        }
    }

    // This method is called while the ice cube is still touching the bowl
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("IceCube"))
        {
            hasIceCube = true; // Ice cube is still in contact with the bowl
        }
    }

    // This method is called when the ice cube stops touching the bowl
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("IceCube"))
        {
            hasIceCube = false; // Ice cube has stopped touching the bowl
            Debug.Log("Ice cube has left the bowl.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Liquid")) // Ensure the pouring stream has the correct tag
        {
            // Increment fill level by a fixed amount
            currentFill += fillRate;
            currentFill = Mathf.Clamp(currentFill, 0, maxFill); // Clamp within range

            // Log the current fill level
            Debug.Log("Current fill level: " + currentFill);

            // Check if the bowl is full
            if (currentFill >= maxFill)
            {
                Debug.Log("Bowl is full!");
            }
            else
            {
                Debug.Log("Bowl is not full yet.");
            }
        }
    }

    // This method is useful to get the current fill level externally
    public float GetFillLevel()
    {
        return currentFill; // Return current fill level for game logic
    }

    // You can also call this method to check if ice is in the bowl
    public bool IsIceCubeInBowl()
    {
        return hasIceCube; // Return true if the ice cube is in contact with the bowl
    }
}

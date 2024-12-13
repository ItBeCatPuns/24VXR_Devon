using UnityEngine;

public class DarkModeTrigger : MonoBehaviour
{
    public bool isDarkMode = false; // The boolean to toggle

    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object entering the trigger has the player tag
        if (other.CompareTag("Player"))
        {
            // Toggle the isDarkMode boolean
            isDarkMode = !isDarkMode;

            Debug.Log($"isDarkMode toggled to: {isDarkMode}");
        }
    }
}

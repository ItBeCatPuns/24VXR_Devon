using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool PlayerHasKey = false; // Set to true when the player picks up the key

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player colliding
        {
            PlayerHasKey = true;
            // Optionally, destroy the key object to indicate it's been picked up
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    // Reference to track if the player has a key
    public bool playerHasKey;

    // Reference to the player GameObject
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the specified player
        if (collision.gameObject == player)
        {
            // Set the playerHasKey variable to true
            playerHasKey = true;

            // Remove the key object from the scene
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetScript : MonoBehaviour
{
    public KeyPickup keyPickup;  // Reference to the KeyPickup script
    public GameObject resetTriggerObject;  // The object that triggers the reset when collided with
    public float resetDelay = 2f; // Time delay before the game resets after collision

    private void Start()
    {
        // Initially, disable the reset trigger object until the player has the key
        resetTriggerObject.SetActive(false);
        Debug.Log("Reset trigger object is initially hidden.");
    }

    void Update()
    {
        // Check if the player has the key
        if (keyPickup.PlayerHasKey)
        {
            if (!resetTriggerObject.activeSelf) // Only log if it's not already active
            {
                Debug.Log("Player has the key, enabling reset trigger object.");
            }
            // Enable the reset trigger object only when the player has the key
            resetTriggerObject.SetActive(true);
        }
    }

    // Trigger event when any object tagged "Player" collides with the reset object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyPickup.PlayerHasKey)
        {
            Debug.Log("Player triggered the reset zone. Resetting game...");
            Invoke("ResetGame", resetDelay);  // The internet told me to do this, it delays the reset
        }
    }

    // Resets the game by reloading the current scene
    void ResetGame()
    {
        Debug.Log("Game is resetting...");
        // Reload the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

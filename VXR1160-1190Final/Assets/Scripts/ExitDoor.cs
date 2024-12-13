using UnityEngine;

public class DoorOpeningScript : MonoBehaviour
{
    public KeyPickup keyPickup;  // Reference to the KeyPickup script
    public Transform door;       // Reference to the door's transform (the object you want to rotate)
    public Vector3 openRotation; // The rotation to open the door (e.g., Vector3(0, 90, 0) for a 90-degree rotation on Y-axis)
    public float openSpeed = 2f; // Speed at which the door rotates

    private Quaternion closedRotation;

    void Start()
    {
        // Store the initial rotation of the door as the closed position
        closedRotation = door.rotation;
    }

    void Update()
    {
        // Check if the player has the key
        if (keyPickup.PlayerHasKey)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        // Lerp (smoothly transition) the door's rotation to the open rotation
        door.rotation = Quaternion.RotateTowards(door.rotation, Quaternion.Euler(openRotation), Time.deltaTime * openSpeed);
    }
}

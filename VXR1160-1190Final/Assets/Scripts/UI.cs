using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class ToggleUIPopup : MonoBehaviour
{
    public GameObject uiPanel;  // The UI panel to toggle
    private InputDevice leftHandDevice;  // The left hand controller (to detect button press)

    void Start()
    {
        // Get the left hand controller input device
        leftHandDevice = GetInputDevice(XRNode.LeftHand);
    }

    void Update()
    {
        // Check if the left Oculus menu button is pressed (three lines button)
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonPressed) && menuButtonPressed)
        {
            // Toggle the UI visibility when the menu button is pressed
            uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }

    // Helper method to get the input device for a specific hand
    private InputDevice GetInputDevice(XRNode node)
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(node, devices);
        return devices.Count > 0 ? devices[0] : default(InputDevice);
    }
}
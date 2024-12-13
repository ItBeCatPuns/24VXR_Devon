using UnityEngine;
using UnityEngine.UI;

public class DarkModeToggleUI : MonoBehaviour
{
    public bool isDarkMode = false; // The boolean to toggle
    public Button toggleButton;    // Reference to the UI Button

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleDarkMode);
        }
    }

    void ToggleDarkMode()
    {
        // Toggles the isDarkMode boolean
        isDarkMode = !isDarkMode;

        Debug.Log($"isDarkMode toggled to: {isDarkMode}");
    }
}

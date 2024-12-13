using UnityEngine;

public class MaterialToggle : MonoBehaviour
{
    public Material lightMaterial;  // The material for light mode
    public Material darkMaterial;   // The material for dark mode
    public DarkModeTrigger darkModeTrigger; // Reference to the DarkModeTrigger script

    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component attached to this object
        objectRenderer = GetComponent<Renderer>();

        // Apply the initial material based on DarkModeTrigger's isDarkMode
        UpdateMaterial();
    }

    void Update()
    {
        // Check the DarkModeTrigger's isDarkMode value and update the material accordingly
        if (darkModeTrigger != null && objectRenderer != null)
        {
            bool isDarkMode = darkModeTrigger.isDarkMode;
            if (isDarkMode != (objectRenderer.sharedMaterial == darkMaterial))
            {
                UpdateMaterial();
            }
        }
    }

    void UpdateMaterial()
    {
        // Switch material based on DarkModeTrigger's isDarkMode value
        if (darkModeTrigger != null && darkModeTrigger.isDarkMode)
        {
            objectRenderer.material = darkMaterial;
        }
        else
        {
            objectRenderer.material = lightMaterial;
        }
    }
}

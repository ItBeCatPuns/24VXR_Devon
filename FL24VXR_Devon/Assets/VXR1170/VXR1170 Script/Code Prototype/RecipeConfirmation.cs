using UnityEngine;

public class RecipeConfirm : MonoBehaviour
{
    public FryingPan fryingPan; // Reference to the FryingPan script
    public GameObject confirmObject; // The object used to confirm the recipe (e.g., a button or clickable object)

    void Start()
    {
        if (confirmObject == null)
        {
            Debug.LogError("Please assign a confirmObject to the RecipeConfirm script.");
        }
    }

    // You can use this method to trigger the confirmation via any input you choose
    public void ConfirmRecipe()
    {
        if (fryingPan != null)
        {
            fryingPan.ConfirmRecipe(); // Call the ConfirmRecipe method from FryingPan
        }
    }

    // Optionally, if you are using a collider or button, you can handle the interaction here:
    void OnMouseDown()
    {
        if (confirmObject != null && fryingPan != null)
        {
            // Assuming the confirmObject is clicked (you can modify the input condition as needed)
            ConfirmRecipe();
        }
    }
}

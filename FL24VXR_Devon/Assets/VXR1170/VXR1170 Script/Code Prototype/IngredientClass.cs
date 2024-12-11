using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientClass : MonoBehaviour
{
    public FryingPan FryingPan;       // Reference to the FryingPan script
    public IngredientType IngType;   // Ingredient type associated with this object

    // Handles ingredient clicks
    public void OnMouseDown()
    {
        // Check if ingredients can still be added
        if (FryingPan != null && FryingPan.canAddIngredients)
        {
            FryingPan.addIngredient(IngType);
        }
        else
        {
            Debug.Log("Cannot add ingredients. Timer has ended.");
        }
    }
}

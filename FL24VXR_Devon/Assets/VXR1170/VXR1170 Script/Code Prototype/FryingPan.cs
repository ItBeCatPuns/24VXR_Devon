using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public int panContents = 0;
    private int panSlot = 0; // Tracks the number of ingredients added
    private int RecipeValue = 0;
    private int generated = 0;

    public Transform[] panspawn;
    public Transform[] UISpawn;
    public GameObject[] Prefabs;
    public GameObject[] Images;
    public int GameScore;

    public bool canAddIngredients = true; // Allows/disallows adding ingredients

    void Start()
    {
        // No confirmation logic here now
    }

    void Update()
    {
        if (generated == 0 && canAddIngredients)
        {
            GenerateRecipe();
        }
    }

    private void GenerateRecipe()
    {
        RecipeValue = 0; // Reset the recipe value
        int RecipeGen1 = Random.Range(0, 4);
        RecipeValue += RecipeGen1 * 100;
        int RecipeGen2 = Random.Range(0, 4);
        RecipeValue += RecipeGen2 * 10;
        int RecipeGen3 = Random.Range(0, 4);
        RecipeValue += RecipeGen3;

        Debug.Log($"New Recipe: {RecipeValue}");

        // Instantiate UI elements for the recipe
        Instantiate(Images[RecipeGen1], UISpawn[0]).transform.SetParent(UISpawn[0]);
        Instantiate(Images[RecipeGen2], UISpawn[1]).transform.SetParent(UISpawn[1]);
        Instantiate(Images[RecipeGen3], UISpawn[2]).transform.SetParent(UISpawn[2]);

        generated++;
    }

    public void addIngredient(IngredientType type)
    {
        if (!canAddIngredients)
        {
            Debug.Log("Cannot add ingredients. Timer has ended.");
            return;
        }

        if (panSlot < 3) // Limit to 3 ingredients
        {
            // Instantiate the ingredient in the correct pan slot
            GameObject ingredient = Instantiate(Prefabs[(int)type], panspawn[panSlot].position, Quaternion.identity);
            ingredient.transform.SetParent(panspawn[panSlot]); // Set as child of the pan slot
            ingredient.transform.localScale = new Vector3(2f, 2f, 2f); // Example: Scale down to 50%

            // Update panContents value based on slot
            if (panSlot == 0) panContents += (int)type * 100;
            if (panSlot == 1) panContents += (int)type * 10;
            if (panSlot == 2) panContents += (int)type;

            Debug.Log($"Pan Contents: {panContents}");
            panSlot++;
        }
        else
        {
            Debug.Log("Pan is full! Click the confirm object to confirm the recipe.");
        }
    }

    public void ConfirmRecipe()
    {
        if (panSlot == 3) // Only confirm if exactly 3 ingredients are present
        {
            // Check if the recipe is correct
            if (RecipeValue == panContents)
            {
                int NetGain = Random.Range(75, 125);
                GameScore += NetGain;
                Debug.Log($"Correct Recipe! Score: {GameScore}");

                // Clear the pan after confirming
                ClearPan();
                ClearRecipeUI();
            }
            else
            {
                Debug.Log("Wrong Recipe! No score awarded.");
            }

            // Reset the pan and contents for the next recipe
            panSlot = 0;
            panContents = 0;
            generated = 0; // Allow new recipe generation
        }
        else
        {
            Debug.Log("Add 3 ingredients before confirming the recipe.");
        }
    }

    private void ClearPan()
    {
        // Clear all ingredients in the pan
        foreach (Transform spawnPoint in panspawn)
        {
            foreach (Transform child in spawnPoint)
            {
                Destroy(child.gameObject); // Destroy all ingredients in the pan
            }
        }
    }

    private void ClearRecipeUI()
    {
        // Clear recipe UI elements
        foreach (Transform child in UISpawn)
        {
            foreach (Transform uiElement in child)
            {
                Destroy(uiElement.gameObject); // Destroy all recipe UI elements
            }
        }
    }
}

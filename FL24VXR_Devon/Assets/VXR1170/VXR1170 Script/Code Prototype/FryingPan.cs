using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public int panContents = 0;
    private int panSlot = 0;
    private int RecipeValue = 0;
    private int generated = 0;

    public Transform[] panspawn;
    public Transform[] UISpawn;
    public GameObject[] Prefabs;
    public GameObject[] Images;
    public int GameScore;

    void Update()
    {
        if (generated == 0)
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
        if (panSlot < 3)
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

        if (panSlot >= 3)
        {
            CheckRecipe();
        }
    }

    private void CheckRecipe()
    {
        if (RecipeValue == panContents)
        {
            int NetGain = Random.Range(75, 125);
            GameScore += NetGain;
            Debug.Log($"Correct Recipe! Score: {GameScore}");
        }
        else
        {
            Debug.Log("Wrong Recipe!");
        }

        // Clear the pan and reset
        ClearPan();
        ClearRecipeUI();
        panSlot = 0;
        panContents = 0;
        generated = 0; // Allow new recipe generation
    }

    private void ClearPan()
    {
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
        foreach (Transform child in UISpawn)
        {
            foreach (Transform uiElement in child)
            {
                Destroy(uiElement.gameObject); // Destroy all recipe UI elements
            }
        }
    }
}

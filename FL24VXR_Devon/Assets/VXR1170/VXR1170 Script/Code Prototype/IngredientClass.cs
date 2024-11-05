using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientClass : MonoBehaviour
{
    public FryingPan FryingPan;
    public IngredientType IngType;
    
    // the code that makes clicking my ingredients a breeze
    public void OnMouseDown()
    {
        FryingPan.addIngredient(IngType);
    }
}

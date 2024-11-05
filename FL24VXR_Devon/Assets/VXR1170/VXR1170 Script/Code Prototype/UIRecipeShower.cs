using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class UIRecipeShower : MonoBehaviour
{
    // this number will become a 3 digit base-5 number, which I will use to check correctness
    public int UIContents = 0;
    // panSlot are the slots where the ingredients get instantiated onto the pan
    int UISlot = 0;
    // evan showed me how to use arrays, (thanks evan), I used these in conjunction with an enumerator to give my ingredients numbers and tell them where to go
    public Transform[] UISpawn;
    public GameObject[] Images;

    // the actual code that instantiates the ingredients on the pan
    public void addUI(IngredientType type)
    {
        if (UISlot < 3)
        {
            int RecipeGen1 = Random.Range(0, 5);
            Instantiate(Images[(int)type], UISpawn[(int)UISlot]);
            if (UISlot == 0) { UIContents += (int)type * 100; }
            if (UISlot == 1) { UIContents += (int)type * 10; }
            if (UISlot == 2) { UIContents += (int)type; Debug.Log((int)RecipeGen1); }
            UISlot++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int RecipeGen1 = Random.Range(0, 4);
        RecipeValue += RecipeGen1 * 100;
        int RecipeGen2 = Random.Range(0, 4);
        RecipeValue += RecipeGen2 * 10;
        int RecipeGen3 = Random.Range(0, 4);
        RecipeValue += RecipeGen3;
        Debug.Log((int)RecipeValue);
        Instantiate(Images[(int)RecipeGen1], UISpawn[(int)0]);
        Instantiate(Images[(int)RecipeGen2], UISpawn[(int)1]);
        Instantiate(Images[(int)RecipeGen3], UISpawn[(int)2]);
    }
    // this number will become a 3 digit base-5 number, which I will use to check correctness
    public int panContents = 0;
    // panSlot are the slots where the ingredients get instantiated onto the pan
    int panSlot = 0;
    int RecipeValue = 0;

    // evan showed me how to use arrays, (thanks evan), I used these in conjunction with an enumerator to give my ingredients numbers and tell them where to go
    public Transform[] panspawn;
    public Transform[] UISpawn;
    public GameObject[] Prefabs;
    public GameObject[] Images;
    public int GameScore;
    // the actual code that instantiates the ingredients on the pan
    void Update()
    {
        int RecipeGen1 = Random.Range(0, 4);
        RecipeValue += RecipeGen1 * 100;
        int RecipeGen2 = Random.Range(0, 4);
        RecipeValue += RecipeGen2 * 10;
        int RecipeGen3 = Random.Range(0, 4);
        RecipeValue += RecipeGen3;
        Debug.Log((int)RecipeValue);
        Instantiate(Images[(int)RecipeGen1], UISpawn[(int)0]);
        Instantiate(Images[(int)RecipeGen2], UISpawn[(int)1]);
        Instantiate(Images[(int)RecipeGen3], UISpawn[(int)2]);
    }

    void addIngredient(IngredientType type)
        {

            if (panSlot < 3)
            {
                Instantiate(Prefabs[(int)type], panspawn[(int)panSlot]);
                if (panSlot == 0) { panContents += (int)type * 100; }
                if (panSlot == 1) { panContents += (int)type * 10; }
                if (panSlot == 2) { panContents += (int)type; }
                Debug.Log((int)panContents);
                panSlot++;
            }
            if (panSlot <= 3)
            {
                if (RecipeValue == panContents)
                {
                    int NetGain = Random.Range(75, 125);
                    GameScore += NetGain;
                    Debug.Log((int)GameScore);
                }
                Destroy(panspawn[0]);
                Destroy(panspawn[1]);
                Destroy(panspawn[2]);
                panSlot = 0;
                
            }
        }
    }
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TMP_Text scoreText;     // Reference to the TextMeshPro UI Text
    public FryingPan fryingPan;   // Reference to the FryingPan script

    void Update()
    {
        // Update the score display
        if (scoreText != null && fryingPan != null)
        {
            scoreText.text = "Score: " + fryingPan.GameScore.ToString();
        }
    }
}

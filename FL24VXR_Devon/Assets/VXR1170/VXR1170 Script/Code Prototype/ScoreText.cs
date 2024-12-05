using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;  // Reference to the TextMeshPro UI Text
    [SerializeField] private FryingPan fryingPan; // Reference to the FryingPan script

    void Update()
    {
        // Update the score display
        scoreText.text = "Score: " + fryingPan.GameScore.ToString();
    }
}

using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;           // TextMeshPro Text to display the timer
    public TMP_Text messageText;         // TextMeshPro Text to display the end message
    public FryingPan fryingPan;          // Reference to the FryingPan script

    private float timeRemaining = 30f;   // Timer duration in seconds
    private bool isCountingDown = true;

    void Update()
    {
        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining > 0)
            {
                timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();
            }
            else
            {
                timerText.text = "Time: 0";
                isCountingDown = false;

                // Disable ingredient addition
                fryingPan.canAddIngredients = false;

                if (messageText != null)
                {
                    messageText.text = "Time's Up!";
                }
            }
        }
    }
}

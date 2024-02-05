using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTime : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText; // Reference to the TextMeshPro component on the UI

    void Start()
    {
        // Retrieve the final elapsed time from PlayerPrefs
        string elapsedTimeString = PlayerPrefs.GetString("FinalElapsedTime", "0.00");
        double finalElapsedTime = double.Parse(elapsedTimeString);

        // Display the final elapsed time in your UI
        DisplayFinalElapsedTime(finalElapsedTime);
    }

    // Update the TMP Text component with the final elapsed time
    private void DisplayFinalElapsedTime(double finalElapsedTime)
    {
        if (finalTimeText != null)
        {
            // Format the final elapsed time as a string (e.g., "Final Elapsed Time: 5.23 seconds")
            string finalElapsedTimeString = "Final Elapsed Time: " + finalElapsedTime.ToString("F2") + " seconds";

            // Update the TextMeshPro component on the UI
            finalTimeText.text = finalElapsedTimeString;
        }
    }
}

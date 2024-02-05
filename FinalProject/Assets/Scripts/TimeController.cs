using System;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [DllImport("plugin")]
    private static extern void StartTimer();

    [DllImport("plugin")]
    private static extern double StopTimer();

    public TextMeshProUGUI elapsedTimeText; // Reference to the TextMeshPro component on the UI
    private bool timerStarted = false;

    private double startTime;

    private void Start()
    {
        // Example: Start the timer when the script starts
        StartTimer();
        timerStarted = true;
        startTime = Time.time; // Record the start time using Unity's time
    }

    private void Update()
    {
        if (timerStarted)
        {
            // Calculate the elapsed time using Unity's time
            double elapsedTime = Time.time - startTime;

            // Update the TMP Text with the elapsed time
            UpdateElapsedTimeUI(elapsedTime);
        }

        // For testing purposes, you can use a key press to stop the timer and save the elapsed time
        
    }

    // Update the TMP Text component with the elapsed time
    private void UpdateElapsedTimeUI(double elapsedTime)
    {
        if (elapsedTimeText != null)
        {
            // Format the elapsed time as a string (e.g., "Elapsed Time: 5.23 seconds")
            string elapsedTimeString = "Elapsed Time: " + elapsedTime.ToString("F2") + " seconds";

            // Update the TextMeshPro component on the UI
            elapsedTimeText.text = elapsedTimeString;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the timer is not stopped and the player collides with a specific GameObject
        if (other.CompareTag("wintrig"))
        {
            double finalElapsedTime = StopTimer();
            // Stop the timer and log the elapsed time
            double elapsedTime = StopTimer();
            Debug.Log("Elapsed Time: " + elapsedTime + " seconds");

            // Set the flag to indicate that the timer is stopped
            timerStarted = false;

            PlayerPrefs.SetString("FinalElapsedTime", finalElapsedTime.ToString());

            // Update the TMP Text with the elapsed time
            UpdateElapsedTimeUI(elapsedTime);
        }
    }
}

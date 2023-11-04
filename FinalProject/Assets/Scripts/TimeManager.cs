using UnityEngine;
using TimeKeeper; // Change this namespace to match the name of your DLL

public class TimeManager : MonoBehaviour
{
    private Timer timer;
    

    void Start()
    {
        timer = new Timer();
        timer.Start();
        // Other initialization code for your game
    }

    void Update()
    {
        // Check win or loss conditions in your game

        if (Input.GetKeyDown(KeyCode.P))
        {
            timer.Stop();
            Debug.Log("Player wins! Time elapsed: " + timer.GetElapsedTime());
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            timer.Stop();
            Debug.Log("Player loses! Time elapsed: " + timer.GetElapsedTime());
        }
    }
}

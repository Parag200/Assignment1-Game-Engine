using UnityEngine;

public class Objective : MonoBehaviour
{
    public string objectiveID;
    public string description;
    public bool isComplete;

    // Reference to the platform trigger script
    public PlatformTrigger platformTrigger;

    private void Start()
    {
        // Register this objective with the ObjectiveManager
        ObjectiveManager.Instance.AddObjective(this);
    }
    private void Update()
    {
        if (platformTrigger.isTriggered)
        {
            Debug.Log("check completion");
            CompleteObjective();
        }
    }


    // Method to be called when the objective is complete
    private void CompleteObjective()
    {
        isComplete = true;
        // Notify the ObjectiveManager that this objective is complete
        ObjectiveManager.Instance.ObjectiveComplete(objectiveID);

        // Debug statement to notify completion (you can customize this message)
        Debug.Log($"Objective '{description}' is complete!");

        // Optionally trigger additional events or actions upon completion
        Destroy(gameObject); // Destroy the objective GameObject once completed
    }
}

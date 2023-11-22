using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static ObjectiveManager Instance;

    public List<Objective> objectives = new List<Objective>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add an objective to the manager
    public void AddObjective(Objective objective)
    {
        objectives.Add(objective);
    }

    // Method to handle when an objective is complete
    public void ObjectiveComplete(string objectiveID)
    {
        Objective objective = objectives.Find(obj => obj.objectiveID == objectiveID);
        if (objective != null)
        {
            // Handle any logic related to completing the objective
            Debug.Log($"Objective Completed: {objective.description}");
        }
    }
}

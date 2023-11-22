using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public EntitySpawner entitySpawner;
    public bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entitySpawner.StartSpawning();
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entitySpawner.StopSpawning();
            isTriggered = false;
        }
    }

    // Method to check if the platform has been triggered
    public bool IsPlatformTriggered()
    {
        return isTriggered;
    }
}

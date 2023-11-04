using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public EntitySpawner entitySpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entitySpawner.StartSpawning(); // Start spawning when the player enters the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entitySpawner.StopSpawning(); // Stop spawning when the player exits the trigger
        }
    }
}

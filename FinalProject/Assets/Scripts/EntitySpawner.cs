using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entityPrefab; // Prefab of the entity to spawn
    public float spawnInterval = 2.0f; // Time between spawns
    private float timer = 0.0f;
    private bool isSpawning = false;

    private void Update()
    {
        // Check if spawning is enabled and the timer exceeds the spawn interval
        if (isSpawning && timer >= spawnInterval)
        {
            SpawnEntity();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void SpawnEntity()
    {
        // Instantiate the entity
        GameObject newEntity = Instantiate(entityPrefab, transform.position, Quaternion.identity);

        // Attach the EntityMovement script to control the entity's movement
        EntityMovement movementScript = newEntity.GetComponent<EntityMovement>();
        if (movementScript != null)
        {
            // Initialize the entity's movement
            movementScript.InitiateMovement();
        }

        // Set up auto-deletion after 5 seconds
        Destroy(newEntity, 5.0f);
    }
}

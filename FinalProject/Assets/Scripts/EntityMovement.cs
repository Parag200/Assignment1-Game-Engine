using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward; // Direction in which the entity moves
    public float moveSpeed = 5.0f; // Speed of the movement
    public float delayBeforeDeactivate = 5.0f; // Delay before deactivating the game object

    private Rigidbody rb;

    // Initialization of the entity's movement
    public void InitiateMovement()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Check if a Rigidbody component is attached to the entity
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the entity.");
            enabled = false; // Disable this script
        }
        else
        {
            // Set the initial velocity to move the entity in the specified direction
            rb.velocity = moveDirection.normalized * moveSpeed;

            // Start the coroutine to deactivate the game object after a delay
            StartCoroutine(DeactivateWithDelay());
        }
    }

    private System.Collections.IEnumerator DeactivateWithDelay()
    {
        // Wait for the specified delay before deactivating the game object
        yield return new WaitForSeconds(delayBeforeDeactivate);

        // Deactivate the game object
        gameObject.SetActive(false);
    }
}

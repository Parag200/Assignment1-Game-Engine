using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyShot(Enemy enemy);
    public static event EnemyShot OnEnemyShot;

    public GameObject projectilePrefab; // Reference to the projectile prefab.
    public Transform shootingPoint; // Point from which the projectiles are shot.

    private bool canShoot = false; // Add this flag to control shooting.

    private void Start()
    {
        // Don't start shooting immediately; wait for the platform trigger.
    }

    private void Update()
    {
        if (canShoot)
        {
            // Simulate the enemy (tower) periodically shooting entities (projectiles).
            ShootEntity();
        }
    }

    private void ShootEntity()
    {
        // Simulate the enemy shooting projectiles.
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        // Optionally, you can add code to set the projectile's direction and velocity.
    }

    public void EnableShooting()
    {
        canShoot = true;
    }
}

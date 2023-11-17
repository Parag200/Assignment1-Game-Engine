using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    Enemy enemy;
    private void OnEnable()
    {
        Enemy.OnEnemyShot += HandleEnemyShot;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyShot -= HandleEnemyShot;
    }

    private void HandleEnemyShot(Enemy enemy)
    {
        // Tower's action when the enemy shoots.
        Debug.Log("Tower is targeting enemy: " + enemy.name);
        // Add your code to respond to the enemy's shots.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damageAmount = 20;  
    // Amount of damage dealt by the trap public to be able to change it later

    private void OnCollision(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Get the Character component from the player
            Character player = other.GetComponent<Character>();

            if (player != null)
            {
                // Apply damage to the player
                player.TakeDamage(damageAmount);
			}
        }
    }
}
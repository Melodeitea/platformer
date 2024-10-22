using UnityEngine;
using UnityEngine.UI; // For using UI components like Slider

public class Health : MonoBehaviour
{
	[Header("Health Settings")]
	public float maxHealth = 100f; // Max health value
	private float currentHealth;   // Current health value

	[Header("UI")]
	public Slider healthBar;       // Reference to the health bar UI Slider

	void Start()
	{
		// Initialize health
		currentHealth = maxHealth;

		// Initialize the health bar UI
		healthBar.maxValue = maxHealth;
		healthBar.value = currentHealth;
	}

	// Method to take damage (called when hitting a trap)
	public void TakeDamage(float amount)
	{
		currentHealth -= amount;

		// Ensure health doesn't go below zero
		if (currentHealth < 0)
			currentHealth = 0;

		// Update the health bar
		healthBar.value = currentHealth;

		// Optionally, check if the player is dead
		if (currentHealth == 0)
		{
			Die();
		}
	}

	// Method to heal (called when picking up a health potion)
	public void Heal(float amount)
	{
		currentHealth += amount;

		// Ensure health doesn't exceed max health
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;

		// Update the health bar
		healthBar.value = currentHealth;
	}

	// Optional: Die method for handling what happens when the health reaches 0
	private void Die()
	{
		Debug.Log("Player Died!");
		// You can trigger death animations, game over screen, etc.
	}
}


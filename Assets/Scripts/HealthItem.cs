using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public GameObject effect;     
    // Particle effect prefab
    public int Regain = 30;       
    // Health restored by the potion, public to be able to change it
    private bool isInInventory = false;

    private float lastClickTime = 0f;
    private float doubleClickTime = 0.25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInInventory = true;  
            // Add to inventory
            gameObject.SetActive(false);  
            // Hide potion from the world
        }
    }

    void Update()
    {
        if (isInInventory && Input.GetMouseButtonDown(0))  
            // Left-click detection
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            //again, used to detect single from double click

            if (timeSinceLastClick <= doubleClickTime)
            {
                Use();
            }

            lastClickTime = Time.time;
            //used to detect if single or double click
        }
    }

    public void Use()
        //basically the take damage script inversed
    {
        isInInventory = false;  
        // "Use" the potion, removing it from inventory
        // did that bc would use the potion when picking it up rather than when clicking within inventory
        Character player = FindObjectOfType<Character>();
        if (player != null)
        {
            player.RegainHealth(Regain);  
            // Restore health

            // Instantiate effect at player's position
            Instantiate(effect, player.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);  
        // Destroy potion object after use
    }
}


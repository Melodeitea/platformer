using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	private Inventory inventory;
	public GameObject itemButton;

	// Start is called before the first frame update
	void Start()
	{
		//inventory is equal to the game object called inventory that is attached to the character that has the player tag
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

	/*when does the object's collider collide with the player's collider?
	 * then we can add to the inventory*/
	void OnTriggerEnter2D(Collider2D other)
	{
		//right tag?
		if (other.CompareTag("Player"))
		{
			//Empty slots?
			for (int i = 0; i < inventory.slots.Length; i++)
			{
				if (inventory.IsFull[i] == false)
				//item can be added to the inventory
				{
					inventory.IsFull[i] = true;
					Instantiate(itemButton, inventory.slots[i].transform, false);
					/*adding item to first free slot and in the same position as said slot,
					*Also we are instantiating as a child of that slot
					*false for it to not be world coordinates but UI coordinates*/
					Destroy(gameObject);
					//destroy cuz it's been picked up
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}

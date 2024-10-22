using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	private Inventory inventory;
	public int i;

	// Start is called before the first frame update
	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		//inventory is equal to the inventory attached to the gameobject that has the tag Player on it blablabla
	}

	// Update is called once per frame
	void Update()
	{
		//does it have any child currently?
		if (transform.childCount <= 0)
		{
			inventory.IsFull[i] = false;
		}
	}
	public void DropItem()
	{
		foreach (Transform child in transform)
		//number of times it is repeated is equal to the number of children in the slots
		{
			child.GetComponent<Spawn>().SpawnDroppedItem();
			GameObject.Destroy(child.gameObject);
			//pretty explicit, please i fucking hate commenting code someone end me right now
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        // object will spaw on new vector based on players x and y position + some so it will spawn near but not on the player
        Vector2 playerPos = new Vector2(player.position.x + 5, player.position.y + 1.5f);
        // item will spawn with 0 rotation
        Instantiate(item, playerPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunItem : MonoBehaviour {

    private Transform player;
    public GameObject effect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use() {
        Instantiate(effect, player.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}

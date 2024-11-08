using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFX : MonoBehaviour
{
[SerializeField]
ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        PlayPS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlayPS()
    {
        _particleSystem.Play();

    }
}

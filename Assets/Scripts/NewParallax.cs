using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxMultiplierX;  // Speed of horizontal parallax movement
    public float parallaxMultiplierY;  // Speed of vertical parallax movement
    private Transform cam;             // Camera transform
    private Vector3 previousCamPos;    // Last frame's camera position

    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position; // Initialize with camera's initial position
    }

    void Update()
    {
        Vector3 deltaMovement = cam.position - previousCamPos; // Calculate camera movement
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplierX, deltaMovement.y * parallaxMultiplierY);
        previousCamPos = cam.position; // Update camera position
    }
}

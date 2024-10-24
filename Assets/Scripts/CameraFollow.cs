using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset;   // Offset position of the camera
    public float smoothSpeed = 0.125f; // Smoothing speed

    void LateUpdate()
    {
        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;
        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optional: Look at the target
        transform.LookAt(target);
    }
}

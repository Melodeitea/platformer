using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
	//basically gonna move the background alongside the camera but slowly decreasing for each layer 
{
	//gonna multiply the deta mvt w the parallax effect value, vector2 bc it's weird if vertical is the same as horizontal :/
	[SerializeField] private Vector2 parallaxEffectMultiplier;
	private Transform cameraTransform;
	//gonna store vector3 (camera mvt) for later
	private Vector3 lastCameraPosition;

	private void Start()
	{
		//bc set on main camera
		cameraTransform = Camera.main.transform;
		//setting cam to pos to where it is rn
		lastCameraPosition = cameraTransform.position;
	}

	//late update rather than update just to be just calculation is done after cam has moved
	private void LateUpdate()
	{
		//to find new position, delta mvt to store how much our camera has moved since last mvt
		Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
		//now we can add this to the background transform position
		transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
		//resetting last.cam.pos to the new one
		lastCameraPosition = cameraTransform.position;
	}

}

/*
 * N
　   O
　　　 O
　　　　 o
　　　　　o
　　　　　 o
　　　　　o
　　　　 。
　　　 。
　　　.
　　　.
　　　 .
　　　　.
*/
﻿using UnityEngine;
using System.Collections;

public class ShakingObject : MonoBehaviour 
{
	public float Speed = 1;
	public float Intensity = 1;
    public float MaxSpeed = 6;
    public float MaxIntensity = 30;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () 
	{
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Test
        if (Speed < MaxSpeed)
        {
            Speed *= (1 + Time.deltaTime / 30);
            if (Speed > MaxSpeed) Speed = MaxSpeed;
        }
        if (Intensity < MaxIntensity)
        {
            Intensity *= (1 + Time.deltaTime / 15);
            if (Intensity > MaxIntensity) Intensity = MaxIntensity;
        }
		Shake ();
	}

	void Shake ()
	{
		float time = Time.time;
		time *= Speed;

		float xOffset = Mathf.PerlinNoise (0, time) - 0.5f;
		xOffset *= Intensity;
		float yOffset = Mathf.PerlinNoise (time, 0) - 0.5f;
		yOffset *= Intensity;

		Vector3 newPosition = originalPosition;
		newPosition.x += xOffset;
		newPosition.y += yOffset;

		transform.position = newPosition; 
	}
}

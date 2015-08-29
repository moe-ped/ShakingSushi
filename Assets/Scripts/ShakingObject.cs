using UnityEngine;
using System.Collections;

public class ShakingObject : MonoBehaviour 
{
	public float Speed = 1;
	public float Intensity = 1;

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
		if (Speed < 6)
		{
			Speed *= (1 + Time.deltaTime / 30);
			Intensity *= (1 + Time.deltaTime / 15);
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

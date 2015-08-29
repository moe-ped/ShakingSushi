using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour 
{
	public GameObject Child;

	public GameObject SpawnObject (GameObject prefab) 
	{
		GameObject spawnedObject = null;
		// Only spawn new sushi if old one is gone
		if (Child == null)
		{
			spawnedObject = (GameObject) Instantiate (prefab, transform.position, Quaternion.identity);
			spawnedObject.transform.SetParent (transform);
			Child = spawnedObject;
			// Because Unity does weird stuff
			spawnedObject.transform.localScale = Vector3.one;
		}
		return spawnedObject;
	}
}

using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour 
{
	private Transform[] Spawnpoints;

	void Start () 
	{
		Spawnpoints = GetComponentsInChildren<Transform> ();
		SpawnSushi ();
	}

	void Update () 
	{

	}

	void SpawnSushi ()
	{
		foreach (Transform spawnpoint in Spawnpoints)
		{
			if (spawnpoint == transform) continue;
			GameObject[] sushiPrefabs = Game.Instance.SushiPrefabs;
			GameObject sushiPrefab = sushiPrefabs[Random.Range(0, sushiPrefabs.Length-1)];
			GameObject sushi = (GameObject) Instantiate (sushiPrefab, spawnpoint.position, Quaternion.identity);
			sushi.transform.SetParent (spawnpoint);
			sushi.transform.localScale = Vector3.one;
		}
	}
}

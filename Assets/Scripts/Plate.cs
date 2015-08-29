using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour 
{
	private Transform[] Spawnpoints;
	private int ChildCount = 0;

	void Start () 
	{
		Spawnpoints = GetComponentsInChildren<Transform> ();
		SpawnSushi ();
	}

	void SpawnSushi ()
	{
		foreach (Transform spawnpoint in Spawnpoints)
		{
			if (spawnpoint == transform) continue;
			ChildCount++;
			GameObject[] sushiPrefabs = Game.Instance.SushiPrefabs;
			GameObject sushiPrefab = sushiPrefabs[Random.Range(0, sushiPrefabs.Length-1)];
			GameObject sushi = (GameObject) Instantiate (sushiPrefab, spawnpoint.position, Quaternion.identity);
			sushi.transform.SetParent (spawnpoint);
			sushi.transform.localScale = Vector3.one;
			var draggableObject = sushi.GetComponent<DraggableObject>();
			draggableObject.GotDestroyed = () => 
			{ 
				ChildCount--;
				if (ChildCount < 1)
				{
					Destroy (gameObject);
				}
			};
		}
	}
}

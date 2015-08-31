using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour 
{
	private int ChildCount = 0;

	public void SpawnSushi (int[] types)
	{
        Transform[] spawnpoints = GetComponentsInChildren<Transform>();
        int i = 0;
        foreach (Transform spawnpoint in spawnpoints)
		{
			if (spawnpoint == transform) continue;
            if (i >= types.Length || i >= spawnpoints.Length+1) return;
			ChildCount++;
			GameObject[] sushiPrefabs = Game.Instance.SushiPrefabs;
			GameObject sushiPrefab = sushiPrefabs[types[i]];
			GameObject sushi = (GameObject) Instantiate (sushiPrefab, spawnpoint.position, Quaternion.identity);
            Game.Instance.OnSushiSpawned(types[i]);
			sushi.transform.SetParent (spawnpoint);
			sushi.transform.localScale = Vector3.one;
			var draggableObject = sushi.AddComponent<DraggableObject>();
			draggableObject.Type = types[i];
			draggableObject.GotDestroyed = (type) => 
			{ 
				ChildCount--;
                Game.Instance.OnSushiDestroyed(type);
				if (ChildCount < 1)
				{
					Destroy (gameObject);
				}
			};
            i++;
		}
	}
}

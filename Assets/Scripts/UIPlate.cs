using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIPlate : MonoBehaviour 
{
	public Action GotDestroyed = () => {};

	private Dictionary<int, List<GameObject>> Children = new Dictionary<int, List<GameObject>>();

    public void SpawnSushi(int[] types)
    {
        Transform[] spawnpoints = GetComponentsInChildren<Transform>();
        int i = 0;
        foreach (Transform spawnpoint in spawnpoints)
        {
            if (spawnpoint == transform) continue;
            if (i >= types.Length || i >= spawnpoints.Length + 1) return;
            GameObject[] sushiPrefabs = Game.Instance.SushiPrefabs;
            GameObject sushiPrefab = sushiPrefabs[types[i]];
            GameObject sushi = (GameObject)Instantiate(sushiPrefab, spawnpoint.position, Quaternion.identity);

			if (!Children.ContainsKey(types[i])) Children.Add(types[i], new List<GameObject>());
			Children[types[i]].Add(sushi);

            Game.Instance.OnSushiSpawned(types[i]);

            sushi.transform.SetParent(spawnpoint);
            sushi.transform.localScale = Vector3.one;

            var uiSushi = sushi.AddComponent<UISushi>();
			uiSushi.Type = types[i];
            uiSushi.GotDestroyed = (type) =>
            {
				bool isEmpty = true;
                foreach (var childrenOfType in Children)
                {
                    if (childrenOfType.Value.Count > 0)
					{
						isEmpty = false;
					}
                }
				if (isEmpty)
				{
					Destroy (gameObject);
				}
            };
            i++;
        }
    }

	public void DestroySushi (int type)
	{
		GameObject sushi = Children [type] [0].gameObject;
		// Remove referennce to this gameObject
		Children [type].RemoveAt(0);
		if (Children[type].Count < 1)
		{

		}
		// Then dispose of it
		Destroy (sushi);
	}

	void OnDestroy ()
	{
		GotDestroyed ();
	}
}

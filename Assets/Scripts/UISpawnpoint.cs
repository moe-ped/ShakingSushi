using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UISpawnpoint : MonoBehaviour 
{
    public Transform Conveyor;

	private List<UIPlate> Plates = new List<UIPlate>();

    public GameObject SpawnObject(GameObject prefab)
    {
        GameObject spawnedObject = null;
        spawnedObject = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
		var uiPlateComponent = spawnedObject.GetComponent<UIPlate> ();
		uiPlateComponent.GotDestroyed = () =>
		{
			if (Plates.Count > 0)
			{
				Plates.RemoveAt (0);
			}
		};
		Plates.Add (uiPlateComponent);
        spawnedObject.transform.SetParent(Conveyor);
        // Because Unity does weird stuff
        spawnedObject.transform.localScale = Vector3.one;
        return spawnedObject;
    }

	public void DestroySushi (int type)
	{
		Plates [0].DestroySushi (type);
	}
}

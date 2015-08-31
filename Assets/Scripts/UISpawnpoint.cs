using UnityEngine;
using System.Collections;

public class UISpawnpoint : MonoBehaviour 
{
    public Transform Conveyor;

    public GameObject SpawnObject(GameObject prefab)
    {
        GameObject spawnedObject = null;
        spawnedObject = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        spawnedObject.transform.SetParent(Conveyor);
        // Because Unity does weird stuff
        spawnedObject.transform.localScale = Vector3.one;
        return spawnedObject;
    }
}

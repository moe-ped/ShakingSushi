using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	public static Game Instance;

	public Transform IgnoreRacastGroup;
	public Transform AllowRacastGroup;
	public Text ScoreText;
	public GameObject[] PlatePrefabs;
	public GameObject[] SushiPrefabs;
	public float TimeBetweenSpawns;
	public List<List<int>> Combinations = new List<List<int>>();

	private Spawnpoint[] Spawnpoints;
    [SerializeField]
    private UISpawnpoint UISpawnpoint;
	private float TimeSinceLastSpawn = 0;
    private List<int> ExistingSushi = new List<int>();

	private int _score;
	public int Score
	{
		get 
		{
			return _score;
		}
		set 
		{
			_score = value;
			ScoreText.text = value.ToString();
		}
	}

	void Start ()
	{
		Instance = this;
		// Because why not ...
		Spawnpoints = GetComponentsInChildren<Spawnpoint>();
        // Kill all the plates already present
        List<Transform> plates = new List<Transform>();
        foreach (var spawnpoint in Spawnpoints)
        {
            Transform[] spcs = spawnpoint.GetComponentsInChildren<Transform>();
            foreach(var spc in spcs)
            {
                if (!spc.GetComponent<Spawnpoint>())
                {
                    plates.Add(spc);
                }
            }
        }
        for (int i = 0; i < plates.Count; i++)
        {
            Destroy(plates[i].gameObject);
        }
		Cursor.visible = false;
		TimeSinceLastSpawn = TimeBetweenSpawns;
	}

	void Update ()
	{
		TimeSinceLastSpawn += Time.deltaTime;
		if (TimeSinceLastSpawn >= TimeBetweenSpawns)
		{
			SpawnObjects ();
			TimeSinceLastSpawn = 0;
            // Test
            SpawnUIPlate();
		}
	}

	void SpawnObjects ()
    {
		List<Spawnpoint> eligibleSpawnpoints = new List<Spawnpoint>();
		foreach (Spawnpoint spawnpoint in Spawnpoints) 
		{
			if (spawnpoint.Child == null)
			{
				eligibleSpawnpoints.Add (spawnpoint);
			}
		}
		if (eligibleSpawnpoints.Count < 1)
		{
			Lose ();
			return;
		}
		GameObject spawnedPlate = eligibleSpawnpoints [Random.Range (0, eligibleSpawnpoints.Count-1)].SpawnObject (PlatePrefabs[Random.Range(0, PlatePrefabs.Length-1)]);
        Plate plateComponent = spawnedPlate.GetComponent<Plate>();
        // Actually spawn objects (sushi)
        int[] types = new int[9];
        for (int i = 0; i < types.Length; i++ )
        {
			types[i] = Random.Range (0, SushiPrefabs.Length-1);
        }
        plateComponent.SpawnSushi(types);
	}

    void SpawnUIPlate ()
    {
        GameObject uiPlate = UISpawnpoint.SpawnObject(PlatePrefabs[1]);
        var uiPlateComponent = uiPlate.GetComponent<UIPlate>();
        // Test
		List<int> spawnableSushi = new List<int> (ExistingSushi);
		int[] types = new int[2];
		for (int i = 0; i < types.Length; i++ )
		{
			if (spawnableSushi.Count < 1) break;
			int index = Random.Range (0, spawnableSushi.Count-1);
			types[i] = spawnableSushi[index];
			spawnableSushi.RemoveAt (index);
		}
        uiPlateComponent.SpawnSushi(types);
		List<int> newCombination = new List<int>(types);
		Combinations.Add (newCombination);
    }

    public void OnSushiSpawned (int type)
    {
        // Do stuff
        ExistingSushi.Add(type);
    }

    public void OnSushiDestroyed (int type)
    {
        // Do stuff
        ExistingSushi.Remove(type);
		// Test if part of combination
		if (Combinations.Count > 0 && Combinations[0].Contains(type))
		{
			// Success
			Debug.Log ("good job!");
			// Destroy sushi on ui plate
			UISpawnpoint.DestroySushi(type);
			// Remove from List
			Combinations[0].Remove(type);
			// Check if list completed
			if (Combinations[0].Count < 1)
			{
				Combinations.RemoveAt(0);
				Score++;
			}
		}
		else
		{
			// Fail
			Debug.Log ("meeep!");
		}
    }

	void Lose ()
	{
		Time.timeScale = 0;
	}
}

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

	private Spawnpoint[] Spawnpoints;
	private float TimeSinceLastSpawn;

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
		Cursor.visible = false;
	}

	void Update ()
	{
		TimeSinceLastSpawn += Time.deltaTime;
		if (TimeSinceLastSpawn >= TimeBetweenSpawns)
		{
			SpawnObjects ();
			TimeSinceLastSpawn = 0;
		}
	}

	void SpawnObjects ()
	{
		// Test
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
		eligibleSpawnpoints [Random.Range (0, eligibleSpawnpoints.Count-1)].SpawnObject (PlatePrefabs[Random.Range(0, PlatePrefabs.Length-1)]);
	}

	void Lose ()
	{
		Time.timeScale = 0;
	}
}

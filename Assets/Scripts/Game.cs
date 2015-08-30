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
    [SerializeField]
    private UISpawnpoint UISpawnpoint;
	private float TimeSinceLastSpawn = 0;
    private Dictionary<int, int> ExistingSushi = new Dictionary<int, int>();

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
            types[i] = Random.Range(0, SushiPrefabs.Length - 1);
        }
        plateComponent.SpawnSushi(types);
	}

    void SpawnUIPlate ()
    {
        GameObject uiPlate = UISpawnpoint.SpawnObject(PlatePrefabs[1]);
        var uiPlateComponent = uiPlate.GetComponent<UIPlate>();
        // Test
        int[] types = new int[6];
        for (int i = 0; i < types.Length; i++)
        {
            types[i] = Random.Range(0, SushiPrefabs.Length - 1);
        }
        uiPlateComponent.SpawnSushi(types);
    }

    public void OnSushiSpawned (int type)
    {
        // Do stuff
        if (!ExistingSushi.ContainsKey(type)) ExistingSushi.Add(type, 0);
        ExistingSushi[type]++;
    }

    public void OnSushiDestroyed (int type)
    {
        // Do stuff
        if (!ExistingSushi.ContainsKey(type)) Debug.LogError ("imaginary sushi destroyed. Dafuq?!");
        ExistingSushi[type]--;
    }

	void Lose ()
	{
		Time.timeScale = 0;
	}
}

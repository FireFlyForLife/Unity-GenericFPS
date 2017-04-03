using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemySpawner : MonoBehaviour {
    public GameObject Prefab;
    public float Depth = 4f;
    public float Width = 2f;
    public float Margin = 2f;

    public bool SpawnOnStart = true;
    public bool KeepSpawning = false;
    public float SpawnDelay = 10f;
    private DelayCheck delay;

	void Start () {
        if (SpawnOnStart)
            SpawnPrefabs();

        delay = new DelayCheck(SpawnDelay, SpawnDelay);
	}
	
	void Update () {
		
	}

    void SpawnPrefabs()
    {

    }
}

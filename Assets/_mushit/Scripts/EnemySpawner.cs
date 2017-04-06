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

        delay = new DelayCheck(SpawnDelay, Time.time);
	}
	
	void Update () {
		if(KeepSpawning && delay.Check(Time.time))
        {
            SpawnPrefabs();
        }
	}

    void SpawnPrefabs()
    {
        int intMargin = Mathf.RoundToInt(Margin);
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        for (int x = 0; x < Width * Margin; x += intMargin)
        {
            for (int y = 0; y < Depth * Margin; y += intMargin)
            {
                Instantiate<GameObject>(Prefab, pos + new Vector3(x, 0, y), rot);
            }
        }
    }
}

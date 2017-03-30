using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberTerrainHeights : MonoBehaviour {
    private float[,] originalHeights;
    private Terrain terrain;

    void Start () {
        this.terrain = GetComponent<Terrain>();
        this.originalHeights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight);
    }

    void OnDestroy()
    {
        terrain.terrainData.SetHeights(0, 0, this.originalHeights);
    }
}

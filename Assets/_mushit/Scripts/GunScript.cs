using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public Transform shotSpawn;
    public GameObject explosionPrefab;
    public ParticleSystem tracerParticle;
    public float maxRange = 40f;
    public float fireDelay = 1f;
    private float lastFire = 0f;
    public int damage = 50;

    void Start () {
        
	}
	
	void Update () {
		if(Input.GetAxisRaw("Fire1") == 1) {
            if(!tracerParticle.isEmitting)
                tracerParticle.Play();

            if (lastFire + fireDelay < Time.time)
            {
                lastFire = Time.time;

                Debug.DrawRay(shotSpawn.position, shotSpawn.forward);

                Vector3 pos = shotSpawn.position;
                Vector3 rot = shotSpawn.forward;

                RaycastHit hit;
                if (Physics.Raycast(pos, rot, out hit, maxRange))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        Instantiate(explosionPrefab, hit.point - rot * 0.5f, Quaternion.identity);

                        BaseCharacter enemy = hit.collider.gameObject.GetComponent<BaseCharacter>();
                        if (enemy != null)
                        {
                            enemy.Health -= damage;
                        }
                    } else if (hit.collider.tag.Equals("Terrain"))
                    {
                        TerrainDeformer deformer = hit.collider.GetComponent<TerrainDeformer>();
                        if(deformer != null)
                        {
                            deformer.DestroyTerrain(hit.point, 10f);
                        }
                    }
                }
            }
        }
        else
        {
            tracerParticle.Stop();
        }
	}
    float desiredHeight = 0.1f;
    void SetTerrainHeight(Terrain terr, Vector3 position, float radius = 5f)
    {
        int hmWidth = terr.terrainData.heightmapWidth;
        int hmHeight = terr.terrainData.heightmapHeight;
        int size = Mathf.RoundToInt(radius);

        // get the normalized position of this game object relative to the terrain
        Vector3 tempCoord = (position - terr.gameObject.transform.position);
        Vector3 coord;
        coord.x = tempCoord.x / terr.terrainData.size.x;
        coord.y = tempCoord.y / terr.terrainData.size.y;
        coord.z = tempCoord.z / terr.terrainData.size.z;
        // get the position of the terrain heightmap where this game object is
        int posXInTerrain = (int)(coord.x * hmWidth);
        int posYInTerrain = (int)(coord.z * hmHeight);
        // we set an offset so that all the raising terrain is under this game object
        int offset = size / 2;
        // get the heights of the terrain under this game object
        float[,] heights = terr.terrainData.GetHeights(posXInTerrain - offset, posYInTerrain - offset, size, size);
        // we set each sample of the terrain in the size to the desired height
        for (int i = 0; i < radius; i++)
            for (int j = 0; j < radius; j++)
                heights[i, j] = desiredHeight;
        // go raising the terrain slowly
        desiredHeight += Time.deltaTime;
        // set the new height
        terr.terrainData.SetHeights(posXInTerrain - offset, posYInTerrain - offset, heights);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public Transform shotSpawn;
    public GameObject explosionPrefab;
    public float maxRange = 40f;
    public float fireDelay = 1f;
    private float lastFire = 0f;
    public int damage = 50;

    void Start () {
        
	}
	
	void Update () {
		if(Input.GetAxisRaw("Fire1") == 1 && lastFire + fireDelay < Time.time) {
            lastFire = Time.time;

            Debug.DrawRay(shotSpawn.position, shotSpawn.forward);

            Vector3 pos = shotSpawn.position;
            Vector3 rot = shotSpawn.forward;

            RaycastHit hit;
            if(Physics.Raycast(pos, rot, out hit, maxRange)) {
                if (hit.collider.tag == "Enemy") {
                    Instantiate(explosionPrefab, hit.point - rot * 0.5f, Quaternion.identity);

                    BaseCharacter enemy = hit.collider.gameObject.GetComponent<BaseCharacter>();
                    if(enemy != null) {
                        enemy.Health -= damage;
                    }
                }
            }
        }
	}
}

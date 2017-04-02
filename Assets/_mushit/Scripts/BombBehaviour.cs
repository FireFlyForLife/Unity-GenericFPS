using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour {
    public GameObject ExplosionEffect;
    public int damage = 250;
    public float radius = 15f;
    public float explosionForce = 35f;

    new Collider collider;
    new Rigidbody rigidbody;

	void Start () {
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

    public void Release()
    {
        Rigidbody parentRidigbody = transform.parent.GetComponentInParent<Rigidbody>();
        if (parentRidigbody)
            rigidbody.velocity = parentRidigbody.velocity;

        transform.parent = null;
        collider.enabled = true;

        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        Vehicle collideVehicle = col.gameObject.GetComponent<Vehicle>();
        if (collideVehicle != null && collideVehicle.canControl)
            return;

        Instantiate<GameObject>(ExplosionEffect, transform.position, Quaternion.identity);

        TerrainDeformer deformer = col.gameObject.GetComponent<TerrainDeformer>();
        if (deformer != null)
        {
            deformer.DestroyTerrain(col.contacts[0].point, explosionForce);
        }

        Vector3 hit = col.contacts[0].point;

        Collider[] colliders = Physics.OverlapSphere(hit, radius);
        foreach(Collider c in colliders)
        {
            Damageable character = c.transform.root.GetComponent<Damageable>();
            if (character != null)
            {
                float dist = (c.transform.position - hit).magnitude;
                int amount = dist == 0 ? damage : Mathf.RoundToInt( radius / dist * damage );
                character.Damage(amount);
            }
        }

        Destroy(gameObject);
    }
}

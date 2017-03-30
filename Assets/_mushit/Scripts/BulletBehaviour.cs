using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    public float StartVelocity;
    public GameObject ExplosionEffect;
    public int damage = 100;
    public float explosionForce = 15f;

    new Rigidbody rigidbody;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity += transform.forward * StartVelocity;
	}

    private void OnCollisionEnter(Collision col)
    {
        Vehicle collideVehicle = col.gameObject.GetComponent<Vehicle>();
        if (collideVehicle != null && collideVehicle.canControl)
            return;

        Instantiate<GameObject>(ExplosionEffect, transform.position, Quaternion.identity);

        TerrainDeformer deformer = col.gameObject.GetComponent<TerrainDeformer>();
        if(deformer != null)
        {
            deformer.DestroyTerrain(col.contacts[0].point, explosionForce);
        }

        Damageable character = col.gameObject.GetComponent<Damageable>();
        if(character != null)
        {
            character.Damage(damage);
        }

        Destroy(gameObject);
    }
}

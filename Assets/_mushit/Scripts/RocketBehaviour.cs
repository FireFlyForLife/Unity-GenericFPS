using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class RocketBehaviour : MonoBehaviour {
    public ParticleSystem ExhaustEffect;
    public GameObject ExplosionEffect;

    public float explosionForce = 20f;
    public float radius = 150;
    public int damage = 100;

    public float delay = 2;

    private DelayCheck delayCheck;
    private bool fired = true;
    private new Rigidbody rigidbody;
    private new Collider collider;

	void Start () {
        delayCheck = new DelayCheck(delay, Time.time);
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

    }
	
	void Update () {
		if(!fired && delayCheck.Check(Time.time))
        {
            fired = true;

            ExhaustEffect.Play();
            rigidbody.useGravity = false;
        }
	}

    public void Release()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        collider.enabled = true;
        fired = false;
        Rigidbody parentRidigbody = transform.parent.GetComponentInParent<Rigidbody>();
        if(parentRidigbody)
            rigidbody.velocity = parentRidigbody.velocity;
        transform.parent = null;
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
        foreach (Collider c in colliders)
        {
            Damageable character = col.gameObject.GetComponent<Damageable>();
            if (character != null)
            {
                float dist = (c.transform.position - hit).magnitude;
                int amount = dist == 0 ? damage : Mathf.RoundToInt(radius / dist * damage);
                character.Damage(amount);
            }
        }

        Destroy(gameObject);
    }
}

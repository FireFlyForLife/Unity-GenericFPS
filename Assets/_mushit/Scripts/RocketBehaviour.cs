using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class RocketBehaviour : MonoBehaviour {
    public ParticleSystem ExhaustEffect;
    public GameObject ExplosionEffect;
    public AudioSource EngineSound;

    public float explosionForce = 20f;
    public float radius = 150;
    public int damage = 100;

    public float delay = 2f;
    public float acceleration = 5f;
    public float startVelocity = 50f;
    public float targetVelocity = 250f;
    private float targetVelocitySqrt;

    private DelayCheck delayCheck;
    private bool fired = false;
    private bool released = false;
    private new Rigidbody rigidbody;
    private new Collider collider;

	void Start () {
        delayCheck = new DelayCheck(delay, Time.time);
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        targetVelocitySqrt = targetVelocity * targetVelocity;
    }
	
	void Update () {
		if(released && ( fired || delayCheck.Check(Time.time)))
        {
            if(rigidbody.velocity.sqrMagnitude < targetVelocitySqrt)
                rigidbody.AddForce(transform.up * acceleration, ForceMode.Acceleration);

            Debug.Log(rigidbody.velocity.magnitude);

            if (!fired)
            {
                fired = true;

                ExhaustEffect.Play();
                EngineSound.Play();
                rigidbody.useGravity = false;
                rigidbody.velocity = transform.up * rigidbody.velocity.magnitude;
            }
        }
	}

    public void Release()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        rigidbody.freezeRotation = true;
        Rigidbody parentRidigbody = transform.parent.GetComponentInParent<Rigidbody>();
        if (parentRidigbody)
            rigidbody.velocity = parentRidigbody.velocity;

        collider.enabled = true;
        fired = false;
        released = true;
        
        transform.parent = null;

        delayCheck = new DelayCheck(delay, Time.time);

        Vehicle controllingVehicle = Player.PlayerController.GetControllingVehicle();
        if (controllingVehicle != null)
        {
            Collider[] vehicleColliders = controllingVehicle.GetComponentsInChildren<Collider>();
            foreach (var col in vehicleColliders)
            {
                Physics.IgnoreCollision(collider, col);
            }
        }
        
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
            Damageable character = c.transform.root.GetComponentInChildren(typeof(Damageable)) as Damageable;
            if (character != null)
            {
                float dist = (c.transform.position - hit).magnitude;
                int amount = dist == 0 ? damage : Mathf.RoundToInt(radius / dist * damage);
                character.Damage(250);//TODO: Change this to the equation
            }
        }

        Destroy(gameObject);
    }
}

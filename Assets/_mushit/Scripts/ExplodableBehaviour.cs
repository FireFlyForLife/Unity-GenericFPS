using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableBehaviour : MonoBehaviour {
    public Texture burnedTexture;
    public GameObject explosionEffect;
    public Vector3 explosionEffectOffset;

    MeshRenderer[] renderers;
    Vehicle vehicle;
    BaseCharacter character;
    bool exploded = false;

	void Start () {
        renderers = GetComponentsInChildren<MeshRenderer>();
        vehicle = GetComponent<Vehicle>();
        character = GetComponent<BaseCharacter>();
	}
	
	void Update () {
        if(!exploded && IsDead())
        {
            ExplodeObject();
        }
	}

    public bool IsDead()
    {
        return (vehicle != null && vehicle.Armour <= 0) || (character != null && character.IsDead());
    }

    public void ExplodeObject()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.mainTexture = burnedTexture;
        }

        if(explosionEffect != null)
        {
            Instantiate<GameObject>(explosionEffect, transform.position + explosionEffectOffset, Quaternion.identity);
        }

        exploded = true;
    }
}

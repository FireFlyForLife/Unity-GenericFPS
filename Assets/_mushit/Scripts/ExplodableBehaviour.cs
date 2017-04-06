using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableBehaviour : MonoBehaviour {
    public Texture burnedTexture;
    public GameObject explosionEffect;

    MeshRenderer[] renderers;

	void Start () {
        renderers = GetComponentsInChildren<MeshRenderer>();
	}
	
	void Update () {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.mainTexture = burnedTexture;
        }
	}
}

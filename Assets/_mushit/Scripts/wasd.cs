using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class wasd : MonoBehaviour {
    public GameObject root;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Damageable>().Damage(250);

    }
}

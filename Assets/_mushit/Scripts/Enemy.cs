using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter {
    public float RotationSpeed = 1000f;

	void Start () {
		
	}
	
	void Update () {
        if (IsDead()) {
            Vector3 rot = Vector3.RotateTowards(transform.forward, Vector3.down, RotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(rot);
        }
	}
}

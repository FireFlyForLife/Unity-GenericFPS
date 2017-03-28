using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetWeaponController : MonoBehaviour
{
    //Rockets
    public GameObject[] Rockets;
    public AudioSource FireRocketSound;
    //mg
    public float fireDelay = 0.1f;
    public Transform gunPosition;
    private float lastFire = 0;
    public AudioSource FireMG;

    Vehicle jet;

	void Start () {
        jet = GetComponent<Vehicle>();
	}
	
	void Update () {
        if (!jet.canControl) return;

        
	}
}

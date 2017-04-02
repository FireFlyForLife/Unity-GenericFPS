using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class JetWeaponController : MonoBehaviour
{
    //Rockets
    public GameObject[] Rockets;
    public AudioSource FireRocketSound;
    public float RocketDelay = 0.75f;
    private DelayCheck RocketDelayCheck;
    private int rocketIndex = 0;
    public int RocketIndex { set { rocketIndex = value; } get { return rocketIndex; } }

    //Bombs
    public GameObject[] Bombs;
    public float BombDropDelay;
    private DelayCheck BombCheck;
    private int bombIndex = 0;
    public int BombIndex { set { bombIndex = value; } get { return bombIndex; } }

    //mg
    public float fireDelay = 0.1f;
    public Transform gunPosition;
    public AudioSource FireMG;
    public GameObject shotPrefab;
    public int MGAmmo = 500;
    public int MaxMGAmmo = 500;
    private DelayCheck MGDelayCheck;

    Vehicle jet;
    new Rigidbody rigidbody;

	void Start () {
        jet = GetComponent<Vehicle>();
        rigidbody = GetComponent<Rigidbody>();

        MGDelayCheck = new DelayCheck(fireDelay);
        RocketDelayCheck = new DelayCheck(RocketDelay);
        BombCheck = new DelayCheck(BombDropDelay);
	}
	
	void Update () {
        if (!jet.canControl) return;
        
        if (Input.GetAxisRaw("Fire1") == 1 && MGAmmo > 0)
        {
            if (MGDelayCheck.Check(Time.time))
            {
                MGAmmo--;

                GameObject bullet = Instantiate<GameObject>(shotPrefab, gunPosition.position, gunPosition.rotation);
                bullet.GetComponent<Rigidbody>().velocity += rigidbody.velocity;
            }
            if (!FireMG.isPlaying)
                FireMG.Play();
        }
        else
        {
            if (FireMG.isPlaying)
                FireMG.Stop();
        }

        if(Input.GetAxisRaw("Rockets") == 1 && RocketDelayCheck.Check(Time.time))
        {
            if(Rockets.Length > rocketIndex)
            {
                GameObject rocket = Rockets[rocketIndex++];
                RocketBehaviour r = rocket.GetComponentInChildren<RocketBehaviour>();
                r.Release();
            }
        }

        if(Input.GetAxisRaw("Jump") == 1 && BombCheck.Check(Time.time))
        {
            if (Bombs.Length > bombIndex)
            {
                GameObject bomb = Bombs[bombIndex++];
                BombBehaviour bombController = bomb.GetComponentInChildren<BombBehaviour>();
                bombController.Release();
            }
        }
    }
}

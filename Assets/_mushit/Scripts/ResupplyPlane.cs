using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ResupplyPlane : MonoBehaviour {
    public float MGAmmoDelay = 0.1f;
    private DelayCheck MGAmmoCheck;
    public float RocketDelay = 1f;
    public GameObject RocketPrefab;
    private DelayCheck RocketCheck;
    public float BombDelay = 2f;
    public GameObject BombPrefab;
    private DelayCheck BombCheck;

    public float maxVelocity = 20;

	void Start () {
        MGAmmoCheck = new DelayCheck(MGAmmoDelay);
        RocketCheck = new DelayCheck(RocketDelay);
        BombCheck = new DelayCheck(BombDelay);
	}
	
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        JetWeaponController jet = other.GetComponentInParent<JetWeaponController>();

        if (jet != null && jet.GetComponent<Rigidbody>().velocity.magnitude < maxVelocity)
        {
            if (jet.MGAmmo < jet.MaxMGAmmo && MGAmmoCheck.Check(Time.time))
            {
                jet.MGAmmo += 1;
            }
            if (jet.Rockets[0].transform.childCount <= 0 && RocketCheck.Check(Time.time))
            {
                GameObject rocket = Instantiate<GameObject>(RocketPrefab);
                rocket.transform.parent = jet.Rockets[--jet.RocketIndex].transform;
                rocket.transform.localPosition = Vector3.zero;
                rocket.transform.localRotation = RocketPrefab.transform.localRotation;
            }
            if (jet.Bombs[0].transform.childCount <= 0 && BombCheck.Check(Time.time))
            {
                GameObject bomb = Instantiate<GameObject>(BombPrefab);
                bomb.transform.parent = jet.Bombs[--jet.BombIndex].transform;
                bomb.transform.localPosition = Vector3.zero;
                bomb.transform.localRotation = BombPrefab.transform.localRotation;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class SoldierBehaviour : BaseCharacter {
    public Transform target;
    public string targetTag;

    public GameObject bulletPrefab;
    public Transform bulletStart;
    public float range = 60f;
    public float shootDelay = 1f;

    NavMeshAgent nav;
    Animator animator;
    DelayCheck shootCheck;

	void Start () {
        if(target == null) target = GameObject.FindGameObjectWithTag(targetTag).transform;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        shootCheck = new DelayCheck(shootDelay);

    }
	
	void Update () {
        if(IsDead())
            return;

        nav.destination = target.position;

        animator.SetBool("Running", nav.velocity.sqrMagnitude > 1);

        GameObject enemy = getVisibleEnemy();
        if(enemy != null && shootCheck.Check(Time.time))
        {
            shootEnemy(enemy);
        }else
        {
            //transform.rotation = Quaternion.identity;
        }
	}

    GameObject getVisibleEnemy()
    {
        Vehicle vehicle = Player.PlayerController.GetControllingVehicle();
        if(vehicle != null && IsInRange(vehicle.gameObject)) //the player is walking
        {
            return vehicle.gameObject;
        }

        GameObject character = Player.PlayerController.pData.PlayerObject;
        if (character != null && IsInRange(character.gameObject))
            return character;

        return null;
    }

    void shootEnemy(GameObject enemy)
    {
        animator.SetTrigger("Shoot");
        transform.LookAt(enemy.transform);

        GameObject bullet = Instantiate<GameObject>(bulletPrefab, bulletStart.position, Quaternion.identity);
        bullet.transform.forward = enemy.transform.position - bulletStart.position;
    }

    public bool IsInRange(GameObject obj)
    {
        return Vector3.Distance(transform.position, obj.transform.position) <= range;
    }

    protected override void OnDeath()
    {
        nav.enabled = false;
        animator.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVehicleBehaviour : Vehicle {
    public Transform target;
    public string targetTag;

    NavMeshAgent nav;

    void Start () {
        if (target == null) target = GameObject.FindGameObjectWithTag(targetTag).transform;
        nav = GetComponent<NavMeshAgent>();
    }

    protected override void UpdateVehicle()
    {
        nav.destination = target.position;

        GameObject enemy = getVisibleEnemy();
        if (enemy != null)
        {
            shootEnemy(enemy);
        }
    }

    public override void OnFatalDamage()
    {
        nav.enabled = false;
        //animator.enabled = false;
    }

    GameObject getVisibleEnemy()
    {
        return null;
    }

    void shootEnemy(GameObject enemy)
    {
        
    }
}

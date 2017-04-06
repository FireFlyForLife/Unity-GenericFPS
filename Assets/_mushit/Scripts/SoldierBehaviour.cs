using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierBehaviour : BaseCharacter {
    public Transform target;
    public string targetTag;

    NavMeshAgent nav;
    Animator animator;

	void Start () {
        if(target == null) target = GameObject.FindGameObjectWithTag(targetTag).transform;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        if(Health <= 0)
        {
            nav.enabled = false;
            animator.enabled = false;

            return;
        }

        nav.destination = target.position;

        animator.SetBool("Running", nav.velocity.sqrMagnitude > 1);

        GameObject enemy = getVisibleEnemy();
        if(enemy != null)
        {
            shootEnemy(enemy);
        }
	}

    GameObject getVisibleEnemy()
    {
        return null;
    }

    void shootEnemy(GameObject enemy)
    {
        animator.SetTrigger("Shoot");
    }
}

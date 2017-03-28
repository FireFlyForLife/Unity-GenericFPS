using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Vehicle {
    public float MovementSpeed = 10f;
    public float BaseTurnSpeed = 10f;

    public float FireDelay = 2;
    float lastFired = 0;

    protected override void init() {
        
    }

    protected override void UpdateVehicle() {
        //Move the mech
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * BaseTurnSpeed * Time.deltaTime);
        transform.position += transform.forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        //Shoot the gun
        if (Input.GetButtonDown("Fire1")) {
            float current = Time.time;
            if(lastFired + FireDelay < current) {
                //TODO: Spawn projectile

                lastFired = current;
            }
        }

        //Rotate the turret
        float mousePos = Input.mousePosition.x;
        
    }
}

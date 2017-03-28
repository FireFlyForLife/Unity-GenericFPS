using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
    public Transform CameraLocation = null;
    public bool canControl = false;
    public Transform ejectPosition;

    public virtual void OnStart()
    {

    }

    public virtual void OnStop()
    {

    }

    private void Awake() {
        if (CameraLocation == null)
            throw new ArgumentNullException("CameraLocation has to be assigned");

        init();
    }
    virtual protected void init() { }

    private void Update() {
        if (canControl)
            UpdateVehicle();
    }
    virtual protected void UpdateVehicle() { }

    private void FixedUpdate() {
        if (canControl)
            FixedUpdateVehicle();
    }
    virtual protected void FixedUpdateVehicle() { }
}

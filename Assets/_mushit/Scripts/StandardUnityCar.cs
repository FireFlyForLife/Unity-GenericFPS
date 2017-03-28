using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class StandardUnityCar : Vehicle {
    public bool startEnabled = false;

    CarUserControl carController;

    protected override void init()
    {
        base.init();

        carController = GetComponent<CarUserControl>();
        carController.enabled = startEnabled;
    }

    public override void OnStart()
    {
        base.OnStart();
        carController.enabled = true;
        carController.m_Car.Move(0, 0, 0, 0);
    }

    public override void OnStop()
    {
        base.OnStop();
        carController.enabled = false;
        carController.m_Car.Move(0, 0, 0, 1);
    }
}

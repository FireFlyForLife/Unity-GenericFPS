using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardUnityVehicle : Vehicle {
    public bool StartEnabled = false;
    public MonoBehaviour UserControlScript;
    public MonoBehaviour AudioController;

    protected override void init()
    {
        base.init();
        UserControlScript.enabled = StartEnabled;
    }

    public override void OnStart()
    {
        base.OnStart();
        UserControlScript.enabled = true;
    }

    public override void OnStop()
    {
        base.OnStop();
        UserControlScript.enabled = false;
    }
}

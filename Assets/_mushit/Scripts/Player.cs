using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : BaseCharacter {
    public PlayerData pData;

    public static Player PlayerController { protected set; get; }

    Vehicle controllingVehicle = null;

    void Awake()
    {
        PlayerController = this;
    }

    void Start () {
        
	}
	
	void Update () {
        if (Input.GetButtonDown("Use")) {
            HandleUse();
        }

        if (controllingVehicle != null)
            return;

        //Do other player things
	}

    public Vehicle GetControllingVehicle()
    {
        return controllingVehicle;
    }

    public void SetControllingVehicle(Vehicle vehicle) {
        Camera cam = Camera.main;

        if (controllingVehicle != null) {
            controllingVehicle.canControl = false;
            controllingVehicle.OnStop();
            if(controllingVehicle.UI != null)
                controllingVehicle.UI.gameObject.SetActive(false);
            cam.transform.parent = pData.CameraPosition;

            pData.PlayerObject.transform.position = controllingVehicle.ejectPosition.position;
            Rigidbody vehicleRigidbody = controllingVehicle.GetComponent<Rigidbody>();
            if (vehicleRigidbody)
            {
                pData.PlayerObject.GetComponent<Rigidbody>().velocity = vehicleRigidbody.velocity;
            }
            SetControl(true);
        }

        controllingVehicle = vehicle;

        if (vehicle != null && vehicle.Armour > 0) {
            vehicle.canControl = true;
            vehicle.OnStart();
            cam.transform.parent = vehicle.CameraLocation;
            if (controllingVehicle.UI != null)
                controllingVehicle.UI.gameObject.SetActive(true);

            SetControl(false);
            SetEnabledRecursivly(false, pData.Gun);
            if(pData.UI != null)
                pData.UI.enabled = false;
        }
        else
        {
            SetEnabledRecursivly(true, pData.Gun);
            if (pData.UI != null)
                pData.UI.enabled = true;
        }

        cam.transform.localPosition = Vector3.zero;
        cam.transform.localRotation = Quaternion.identity;
    }

    void HandleUse() {
        if (controllingVehicle == null) {
            RaycastHit hit;
            if (Physics.Raycast(pData.Front.position, pData.Front.transform.forward, out hit, 100f)) {
                Vehicle vehicle = hit.collider.GetComponentInParent<Vehicle>();
                if(vehicle != null)
                    SetControllingVehicle(vehicle);
            }
        } else {
            SetControllingVehicle(null);
        }
    }

    void SetControl(bool state) {
        SetEnabledRecursivly(state, pData.PlayerObject);
    }

    void SetEnabledRecursivly(bool state, GameObject obj)
    {
        //set all monobehavior components to disabled
        MonoBehaviour[] components = obj.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour behaviour in components)
        {
            behaviour.enabled = state;
        }

        //call for all children
        for(int i = 0; i < obj.transform.childCount; i++)
        {
            SetEnabledRecursivly(state, obj.transform.GetChild(i).gameObject);
        }

        obj.SetActive(state);
    }
}

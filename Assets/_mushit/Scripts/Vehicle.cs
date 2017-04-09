using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, Damageable, Destroyable
{
    public Transform CameraLocation = null;
    public Transform ejectPosition;
    public Canvas UI;
    public bool preventRigidbodySleeping = false;
    private new Rigidbody rigidbody;
    public bool canControl = false;
    public bool isAI = false;

    private int _armour = 100;
    public int Armour {
        set {
            _armour = value;
            if(_armour <= 0)
            {
                OnFatalDamage();
                if(canControl)
                    Player.PlayerController.SetControllingVehicle(null);
            }
        }
        get {
            return _armour;
        }
    }

    public virtual void OnStart()
    {
    }

    public virtual void OnStop()
    {
    }

    public virtual void OnFatalDamage()
    {
    }

    private void Awake() {
        if (CameraLocation == null && !isAI)
            throw new ArgumentNullException("CameraLocation has to be assigned");

        init();
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    virtual protected void init() { }

    private void Update() {
        if (preventRigidbodySleeping && rigidbody.IsSleeping())
            rigidbody.WakeUp();

        if ((canControl || isAI) && Armour > 0)
            UpdateVehicle();
    }
    virtual protected void UpdateVehicle() { }

    private void FixedUpdate() {
        if ((canControl || isAI) && Armour > 0)
            FixedUpdateVehicle();
    }
    virtual protected void FixedUpdateVehicle() { }

    public void Damage(int amount)
    {
        Armour -= amount;
    }

    public bool isDestroyed()
    {
        return Armour <= 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetUIBehaviour : MonoBehaviour {
    public GameObject Jet;
    public Text MGAmmoCounter;
    public Text RocketCounter;
    public Text BombCounter;
    public Text ArmourCounter;

    private Vehicle controller;
    private JetWeaponController weaponController;

	// Use this for initialization
	void Start () {
        controller = Jet.GetComponent<Vehicle>();
        weaponController = Jet.GetComponent<JetWeaponController>();
	}
	
	// Update is called once per frame
	void Update () {
        RefreshUI();
	}

    void RefreshUI()
    {
        MGAmmoCounter.text = "MG Ammo: " + weaponController.MGAmmo;
        RocketCounter.text = "Rockets: " + (weaponController.Rockets.Length - weaponController.RocketIndex);
        BombCounter.text = "Bombs: " + (weaponController.Bombs.Length - weaponController.BombIndex);

        ArmourCounter.text = "Armour: " + controller.Armour;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Making this class A MonoBehaviour so we can reference it on our playercontroller, so we can have multiple players and have all the setting on the prefab
public class PlayerData : MonoBehaviour
{
    public Transform Front;
    public Transform CameraPosition;
    public GameObject Gun;
    public GameObject PlayerObject;
    public Canvas UI;
}

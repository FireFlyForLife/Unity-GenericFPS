using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIBehaviour : MonoBehaviour {
    public Text HealthCounter;

    Player player;
    GunScript gun;

    void Start()
    {
        
    }

    void Update () {
        if(player == null)
        {
            player = Player.PlayerController;
            gun = player.pData.PlayerObject.GetComponent<GunScript>();
        }

        UpdateCounters();
	}

    void UpdateCounters()
    {
        HealthCounter.text = "Health: " + player.Health;
    }
}

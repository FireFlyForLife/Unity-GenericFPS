using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {
    public bool startEnabled = false;

    ParticleSystem particles;

	void Start () {
        particles = GetComponent<ParticleSystem>();
        if (startEnabled)
            particles.Play();
        else
            particles.Stop();
	}


}

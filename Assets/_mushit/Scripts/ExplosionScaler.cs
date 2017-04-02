using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ExplosionScaler : MonoBehaviour {
    public float radius = 10f;

    ParticleSystem system;

    private void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = system.main;
        main.startSizeMultiplier = radius;
    }
}
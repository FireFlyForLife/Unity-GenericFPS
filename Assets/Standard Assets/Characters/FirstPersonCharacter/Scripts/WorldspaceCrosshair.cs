using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldspaceCrosshair : MonoBehaviour {
    public Transform target;
    public Vector3 offset;

	void Start () {
        if (target == null)
            throw new ArgumentNullException("Target needs to be assigned");
		if(offset == null)
        {
            offset = transform.position - target.transform.position;
        }
	}

    private void LateUpdate()
    {
        Vector3 worldpos = target.position + offset;
        Vector3 screen = Camera.main.WorldToScreenPoint(worldpos);
        transform.position = screen;
    }
}

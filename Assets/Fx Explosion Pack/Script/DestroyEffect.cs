using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
    public float lifetime = float.MaxValue;

    void Update ()
	{
        Destroy(gameObject, lifetime);

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	
	}
}

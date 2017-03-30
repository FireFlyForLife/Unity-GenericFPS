using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
    public float lifetime = float.MaxValue;
    float starttime;

    void Start()
    {
        starttime = Time.time;
    }

    void Update ()
	{
        if(Time.time > starttime + lifetime)
        {
            Destroy(gameObject);
        }

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	
	}
}

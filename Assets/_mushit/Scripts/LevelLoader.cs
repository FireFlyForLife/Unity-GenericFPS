using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
		
	}

    public void setlevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void setDeformTerrain(bool b)
    {
        Settings.SetValue("DeformTerrain", b);
    }

    public void setDeformTexture(bool b)
    {
        Settings.SetValue("DeformTexture", b);
    }
}

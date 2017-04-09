using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public GameObject root;
    public MonoBehaviour mouseBlockScript;
    bool isPause = false;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        SetPause(!isPause);
    }

    public void SetPause(bool state)
    {
        isPause = state;

        if (isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        Cursor.visible = isPause;
        root.SetActive(isPause);
        mouseBlockScript.enabled = !isPause;
    }

    public bool GetPause()
    {
        return isPause;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        SetPause(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}

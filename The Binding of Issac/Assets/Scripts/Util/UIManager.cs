using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject _menuSet;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (_menuSet.activeSelf)
			{
				Resume();
			}
            else
            {
				Pause();
			}
		}
    }

	public void Resume()
	{
		_menuSet.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	void Pause()
	{
		_menuSet.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void QuitGame()
	{

	}
}

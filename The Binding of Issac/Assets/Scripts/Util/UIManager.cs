using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject _menuSet;
	public GameObject _DeadMenu;
	int gameScene = 1;

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

		if (PlayerController.isDie == true)
		{
			StartCoroutine(WaitingMenu());
		}

		if (_DeadMenu.activeSelf)
		{
			if (Input.GetKeyDown (KeyCode.Escape))
			{
				Application.Quit();
			}
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space))
			{
				PlayerController.isDie = false;
				SceneManager.LoadScene(gameScene);
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
		Application.Quit();
	}

	IEnumerator WaitingMenu()
	{
		yield return new WaitForSeconds(2f);
		_DeadMenu.SetActive(true);
		FindObjectOfType<AudioManager>().Play("PlayerDied");
		Time.timeScale = 0f;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject _menuSet;
	public GameObject _DeadMenu;

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

	IEnumerator WaitingMenu()
	{
		yield return new WaitForSeconds(2f);
		_DeadMenu.SetActive(true);
		Time.timeScale = 0f;
	}
}

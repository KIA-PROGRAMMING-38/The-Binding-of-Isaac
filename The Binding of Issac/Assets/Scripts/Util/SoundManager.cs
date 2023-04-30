using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

	private void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(_instance);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SFXPlay(string sfxName, AudioClip clip)
	{
		GameObject go = new GameObject(sfxName + "Sound");
		AudioSource audioSource = go.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();

		Destroy(go, clip.length);
	}
}

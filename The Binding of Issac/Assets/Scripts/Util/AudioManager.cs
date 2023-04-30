using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound._source = gameObject.AddComponent<AudioSource>();
            sound._source.clip = sound._clip;

            sound._source.volume = sound.volume;
            sound._source.pitch = sound.pitch;
            sound._source.loop = sound.loop;
        }
    }

	private void Start()
	{
        Play("Theme");
	}

	public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        sound._source.Play();
    }

	public void Stop(string name) 
	{
		Sound sound = Array.Find(sounds, sound => sound.name == name);
		if (sound == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		sound._source.volume = sound.volume * (1f + UnityEngine.Random.Range(-sound.volume / 2f, sound.volume / 2f));
		sound._source.pitch = sound.pitch * (1f + UnityEngine.Random.Range(-sound.pitch / 2f, sound.pitch / 2f));

		sound._source.Stop();
	}
}

using System.Collections;
using UnityEngine;

public class MaintitleAudio : MonoBehaviour
{
	public AudioClip firstAudioClip;
	public AudioClip secondAudioClip;

	private void Start()
	{
		StartCoroutine(PlayTwoAudioClips(firstAudioClip, secondAudioClip));
	}

	IEnumerator PlayTwoAudioClips(AudioClip firstClip, AudioClip secondClip)
	{
		while (true)
		{
			GetComponent<AudioSource>().clip = firstClip;
			GetComponent<AudioSource>().Play();
			yield return new WaitForSecondsRealtime(firstClip.length);

			GetComponent<AudioSource>().clip = secondClip;
			GetComponent<AudioSource>().Play();
			yield return new WaitForSecondsRealtime(secondClip.length);
		}
	}
}

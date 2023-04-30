using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public int index;
    public string levelName;

    AudioSource _audio;
    public AudioClip _clip;
    public Animator _fadeAnimator;
    public Animator _loadAnimator;

	private void Awake()
	{
		_audio = GetComponent<AudioSource>();
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
		_fadeAnimator.SetTrigger("FadeOut");
        _audio.Stop();
        SoundManager._instance.SFXPlay("LoadSFX", _clip);
        yield return new WaitForSeconds(4.5f);

		_fadeAnimator.SetTrigger("FadeIn");
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    PlayerController _playerCon;

    public Image[] _hearts;
    public Sprite _fullHeart;
    public Sprite _emptyHeart;

	private void Awake()
	{
		_playerCon = GetComponent<PlayerController>();
	}

    void Update()
    {
        //foreach (Image image in _hearts)
        //{
        //    image.sprite = _emptyHeart;
        //}

        //for (int i = 0; i < _playerCon.currentHealth; i++)
        //{
        //    _hearts[i].sprite = _fullHeart;
        //}

        if(_playerCon.currentHealth > _playerCon.currentMaxHealth)
        {
            _playerCon.currentHealth = _playerCon.currentMaxHealth;
        }

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _playerCon.currentHealth)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }

            if (i < _playerCon.currentMaxHealth)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}

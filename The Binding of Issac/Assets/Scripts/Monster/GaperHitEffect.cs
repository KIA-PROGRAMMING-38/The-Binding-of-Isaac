using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GaperHitEffect : MonoBehaviour
{
	public float health;
	Animator _animator;

	[SerializeField]
	private SpriteRenderer _head;
	[SerializeField]
	private SpriteRenderer _body;

	Rigidbody2D _monsterRb;
	PlayerController _playerController;
	Collider2D _gaperCD;

	private void Awake()
	{
		_gaperCD = GetComponent<Collider2D>();
		_animator = GetComponent<Animator>();
		_monsterRb = GetComponent<Rigidbody2D>();
		_playerController = GameObject.Find("Isaac_Body").GetComponent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Transform childObject = transform.Find("Gaper_Body");
		if (collision.gameObject.CompareTag("tears"))
		{
			if (_playerController != null)
			{
				StartCoroutine(DamageEffect());
				_monsterRb.velocity = Vector2.zero;
				health -= _playerController.attackPower;
			}

			if (health <= 0)
			{
				_animator.SetTrigger("Dead");
				_gaperCD.enabled = false;
				childObject.gameObject.SetActive(false);
			}
		}
	}

	IEnumerator DamageEffect()
	{
		_head.color = new Color32(255, 0, 0, 255);
		_body.color = new Color32(255, 0, 0, 255);
		yield return new WaitForSeconds(0.1f);

		_head.color = new Color32(255, 255, 255, 255);
		_body.color = new Color32(255, 255, 255, 255);
	}

	void Dead()
	{
		Destroy(gameObject);
	}
}

using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
	public float health;

	public bool isLive = false;

	PlayerController _playerController;
	SpriteRenderer _spriteRenderer;
	Rigidbody2D _monsterRb;
	Collider2D _collider;
	Animator _animator;
	WaitForSeconds _waitForSeconds;


	private void Awake()
	{
		_waitForSeconds = new WaitForSeconds(0.1f);
		_collider = GetComponent<Collider2D>();
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_monsterRb = GetComponent<Rigidbody2D>();
		_playerController = GameObject.Find("Isaac_Body").GetComponent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("tears"))
		{
			if (_playerController != null)
			{
				StartCoroutine(DamageEffect());
				_monsterRb.velocity = Vector2.zero;
				health -= _playerController.attackPower;
				Debug.Log(health);
			}

			if (health <= 0)
			{
				_animator.SetTrigger("Dead");
				isLive = true;
			    _collider.enabled = false;
				FindObjectOfType<AudioManager>().Play("MonsterDeath");
			}
		}
	}

	IEnumerator DamageEffect()
	{
		_spriteRenderer.color = new Color32(255, 0, 0, 255);
		yield return _waitForSeconds;

		_spriteRenderer.color = new Color32(255, 255, 255, 255);
		yield return _waitForSeconds;
	}

	void Dead()
	{
		gameObject.SetActive(false);
	}

	void Stop()
	{
		_monsterRb.velocity = Vector2.zero;
	}
}


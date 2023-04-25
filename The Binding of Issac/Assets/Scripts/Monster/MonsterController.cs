using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
	public float health;

	PlayerController _playerController;
	SpriteRenderer _spriteRenderer;
	Rigidbody2D _monsterRb;
	Collider2D _collider;
	Animator _animator;

	private void Awake()
	{
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
			    _collider.enabled = false;
			}
		}
	}

	IEnumerator DamageEffect()
	{
		_spriteRenderer.color = new Color32(255, 0, 0, 255);
		yield return new WaitForSeconds(0.1f);
		_spriteRenderer.color = new Color32(255, 255, 255, 255);
		yield return new WaitForSeconds(0.1f);
	}

	void Dead()
	{
		Destroy(gameObject);
	}

	void Stop()
	{
		_monsterRb.velocity = Vector2.zero;
	}
}


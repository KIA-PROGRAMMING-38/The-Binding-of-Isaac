using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTear : MonoBehaviour
{
	Animator _animator;
	Rigidbody2D _tearRigidbody;
	PlayerDamaged _playerDamaged;

	private float _damage = 1;

	private void Awake()
	{
		_playerDamaged = GameObject.Find("PlayerHitBox").GetComponent<PlayerDamaged>();
		_tearRigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Enemy") && _playerDamaged.isInvincibleTime == false)
		{
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
			_animator.SetBool("Burst", true);

			if (playerController != null)
			{
				if (playerController.currentHealth > _damage)
				{
					_playerDamaged.isInvincibleTime = true;
					_playerDamaged.PlayHitAnim();
					StartCoroutine(_playerDamaged.InvincibleTime());
				}
				playerController.SetHealth(-_damage);
			}
		}
	}

	void StopTear()
	{
		_tearRigidbody.velocity = Vector2.zero;
	}

	void OffAnim()
	{
		gameObject.SetActive(false);
	}

}

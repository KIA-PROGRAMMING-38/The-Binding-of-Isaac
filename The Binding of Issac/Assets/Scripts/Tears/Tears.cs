using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : MonoBehaviour
{
	public float _damage = 3.5f;

	Animator _animator;
	Rigidbody2D _tearRigidbody;

	private void Awake()
	{
		_tearRigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	float _elpasedTime;
	[SerializeField]
	float _dropTime;
	[SerializeField]
	float _dropSpeed;
	bool _curved = false;

	[SerializeField] Vector2 _moveDirection;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Player"))
		{
			_animator.SetBool("Burst", true);
			_moveDirection.y = 0;
		}
	}

	private void FixedUpdate()
	{
		_elpasedTime += Time.fixedDeltaTime;

		if (_elpasedTime > _dropTime && _curved == false)
		{ 
			_animator.SetBool("Burst", true);
			_tearRigidbody.velocity += _moveDirection;
			_curved = true;
		}
	}

	private void OnEnable()
	{
		_moveDirection.y = -3.5f;
	}

	private void OnDisable()
	{
		_animator.SetBool("Burst", false);
		_curved = false;
		_elpasedTime = 0;

	}

	void OffAnim()
	{
		gameObject.SetActive(false);
	}

	void StopTear()
	{
		_tearRigidbody.velocity = Vector2.zero;
	}

	void BlockingSound()
	{
		FindObjectOfType<AudioManager>().Play("TearBlock");
	}
}

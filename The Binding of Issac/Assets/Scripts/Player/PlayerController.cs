using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// public float health { get { return currentHealth; }}
	public float currentHealth;
	public float moveSpeed = 5f;
	public float friction = 2f;

	public const float isaacBaseHealth = 3;
	public const float maxHealth = 12;
	public const float maxSpeed = 10f;

	bool isDie = false;

	Rigidbody2D _rigid;
	PlayerInput _playerInput;
	public GameObject _headObject;
	private Animator _headAnimator;

	private void Awake()
	{
		_headAnimator = _headObject.GetComponent<Animator>();
		_playerInput = GetComponent<PlayerInput>();
		_rigid = GetComponent<Rigidbody2D>();
	}
	void Start()
    {
		currentHealth = isaacBaseHealth;
		Debug.Log(currentHealth);
    }

	void Update()
	{
		
	}

    void FixedUpdate()
	{
		Vector2 direction = new Vector2(_playerInput.Horizontal, _playerInput.Vertical).normalized;

		if (direction.magnitude > 0f)
		{
			_rigid.velocity = direction * moveSpeed;

			if (_rigid.velocity.magnitude > maxSpeed)
			{
				_rigid.velocity = _rigid.velocity.normalized * maxSpeed;
			}
		}
		else
		{
			_rigid.velocity -= _rigid.velocity * friction * Time.fixedDeltaTime;
		}
	}

	public void SetHealth(int health)
	{
		if (currentHealth <= 0)
		{
			Die();
		}

		currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
		Debug.Log(currentHealth + "/" + maxHealth);
	}	

	void Die()
	{
		_headAnimator.SetTrigger("PlayerDead");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// if (collision.gameObject.CompareTag("Enemy"))
	}
}	

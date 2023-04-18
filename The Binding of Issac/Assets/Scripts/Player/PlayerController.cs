using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// public float health { get { return currentHealth; }}
	public float baseHealth = 3;
	public float maxHealth = 12;
	public float currentHealth;
	public float currentMaxHealth;
	public float attackPower = 3.5f;
	public float moveSpeed = 5f;

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float friction = 2f;

	bool isDie = false;

	public GameObject _headObject;
	private Animator _headAnimator;
	Rigidbody2D _rigid;
	PlayerInput _playerInput;

	private void Awake()
	{
		_headAnimator = _headObject.GetComponent<Animator>();
		_playerInput = GetComponent<PlayerInput>();
		_rigid = GetComponent<Rigidbody2D>();
	}
	void Start()
    {
		currentHealth = baseHealth;
		currentMaxHealth = baseHealth;
		Debug.Log(currentHealth);
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

		currentHealth = Mathf.Clamp(currentHealth + health, 0, currentMaxHealth);
		Debug.Log(currentHealth + "/" + currentMaxHealth);
	}

	public void SetCurrnetMaxHealth(int health)
	{
		currentMaxHealth = Mathf.Clamp(currentMaxHealth + health, 0, maxHealth);
		Debug.Log(currentMaxHealth);
		Debug.Log(currentHealth + "/" + currentMaxHealth);
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

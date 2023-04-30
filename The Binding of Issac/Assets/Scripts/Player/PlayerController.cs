using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static bool isDie = false;

	// public float health { get { return currentHealth; }}
	public float baseHealth = 3;
	public float maxHealth = 12;
	public float currentHealth;
	public float currentMaxHealth;
	public float attackPower = 3.5f;
	public float moveSpeed = 5f;

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float friction = 2f;

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
		if (isDie == false)
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
	}

	// 현재 체력 상승
	public void SetHealth(float health)
	{
		currentHealth = Mathf.Clamp(currentHealth + health, 0, currentMaxHealth);
		if (currentHealth <= 0)
		{
			Die();
		}

		Debug.Log(currentHealth + "/" + currentMaxHealth);
	}

	// 최대 체력 상승
	public void SetCurrnetMaxHealth(float health)
	{
		currentMaxHealth = Mathf.Clamp(currentMaxHealth + health, 0, maxHealth);
		Debug.Log(currentMaxHealth);
		Debug.Log(currentHealth + "/" + currentMaxHealth);
	}

	void Die()
	{
		FindObjectOfType<AudioManager>().Play("PlayerDeath");
		FindObjectOfType<AudioManager>().Stop("Theme");
		isDie = true;
		_rigid.velocity = Vector2.zero;
		_headAnimator.SetTrigger("PlayerDead");
		StartCoroutine(WatingDiesTime());
	}

	IEnumerator WatingDiesTime()
	{
		yield return new WaitForSeconds(1f);
	}
}

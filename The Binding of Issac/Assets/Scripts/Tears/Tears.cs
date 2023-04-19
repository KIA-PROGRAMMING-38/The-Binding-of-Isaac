using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Tears : MonoBehaviour
{
	Animator _animator;
	Rigidbody2D _tearRigidbody;
	TearsShoot _tearsShoot;

	//[SerializeField] private Transform _originalPosition; // 떨어지기 시작할 지점
	//[SerializeField] private Transform _dropPosition; //떨어질 지점

	private IObjectPool<Tears> _managedPool;

	private void Awake()
	{
		_tearsShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
		_tearRigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	float _elpasedTime;
	[SerializeField]
	float _dropTime;
	[SerializeField]
	float _dropSpeed;
	bool _curved = false;

	public Vector2 _moveDirection;

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

	public void SetManagedPool(IObjectPool<Tears> pool)
	{
		_managedPool = pool;
	}

	public void ReturnToPool()
	{
		_managedPool.Release(this);
	}

	public void DestroyTears()
	{
		Invoke("ReturnToPool", 3f);
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
}

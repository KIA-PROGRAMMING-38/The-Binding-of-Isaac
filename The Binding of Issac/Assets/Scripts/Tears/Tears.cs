using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Tears : MonoBehaviour
{
	Animator _animator;
	TearsShoot _tearsShoot;

	private IObjectPool<Tears> _managedPool;

	private void Awake()
	{
		_tearsShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		float distance = Vector2.Distance(transform.position, _tearsShoot.transform.position);

		// 눈물이 발사된 후 일정 거리까지만 이동한 후에 비활성화
		if (distance >= _tearsShoot.tearRange)
		{
			gameObject.SetActive(false);
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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Player"))
		{
			_animator.SetTrigger("TearsEffect");
			StartCoroutine(Effect());
		}
	}

	IEnumerator Effect()
	{
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);	
	}
}

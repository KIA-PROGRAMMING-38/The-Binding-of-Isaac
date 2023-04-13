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
		_tearsShoot = GetComponent<TearsShoot>();
		_animator = GetComponent<Animator>();
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
			_animator.SetBool("isHit", true);
			StartCoroutine(Effect());
		}
	}

	IEnumerator Effect()
	{
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);
	}
}

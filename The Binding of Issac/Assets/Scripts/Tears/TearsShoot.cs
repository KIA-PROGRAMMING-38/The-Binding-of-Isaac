using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class TearsShoot : MonoBehaviour
{ 
	public float shotSpeed;
	public float tearSpeed = 2f;
	public float tearRange = 1.1f;
	private bool isDelay;

	public GameObject _tearsPrefabs;
	Animator _animator;
	Tears _tears;

	private Vector2[] _directions = { Vector2.down, Vector2.up, Vector2.right, Vector2.left };
	private IObjectPool<Tears> _Pool;
	
	void Start()
	{
		_animator = GetComponent<Animator>();
		_Pool = new ObjectPool<Tears>(CreateTear, OnGetTear, OnReleaseTear, OnDestroyTear, maxSize: 20);	
	}

	void Update()
	{
		_animator.SetFloat("AttackSpeed", tearSpeed);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (!isDelay)
			{
				isDelay = true;
				directionsIndex = 3;                   // 연속 클릭 방지 실험으로 잠시 구현한 코드
				_animator.SetBool("leftFire", true);
				StartCoroutine(AttackDelay());
			}
		}
		else if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			_animator.SetBool("leftFire", false);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			directionsIndex = 2;
			_animator.SetBool("rightFire", true);
		}
		else if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			_animator.SetBool("rightFire", false);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			directionsIndex = 0;
			_animator.SetBool("downFire", true);
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			_animator.SetBool("downFire", false);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			directionsIndex = 1;
			_animator.SetBool("upFire", true);
		}
		else if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			_animator.SetBool("upFire", false);
		}		
	}

	int directionsIndex = -1;
	void FireTear()
	{
		var tears = _Pool.Get();
		Rigidbody2D rigid = tears.GetComponent<Rigidbody2D>();
		rigid.AddForce(_directions[directionsIndex] * shotSpeed, ForceMode2D.Impulse);
		tears.transform.position = transform.position;
		tears.DestroyTears();
	}

	IEnumerator AttackDelay()
	{
		yield return new WaitForSeconds(0.3f);
		isDelay = false;
	}

	private Tears CreateTear()
	{
		Tears tears = Instantiate(_tearsPrefabs).GetComponent<Tears>();
		tears.SetManagedPool(_Pool);
		return tears;
	}

	private void OnGetTear(Tears tears)
	{
		tears.gameObject.SetActive(true);
	}

	private void OnReleaseTear(Tears tears)
	{
		tears.gameObject.SetActive(false);
	}

	private void OnDestroyTear(Tears tears)
	{
		Destroy(tears.gameObject);
	}
}

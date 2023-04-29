using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MonstroController : MonoBehaviour
{
	[SerializeField] float tearSpeed = 5;
	private int DIRECTION = -1;
	public int numberOfTears = 6;

	public GameObject _tearsPrefabs;
	public Transform _player;
	public Transform _shotPoint;
	private Rigidbody2D _rigid;
	private Animator _animaotr;
	private Collider2D _collider;
	MonsterController _monsterController;
	WaitForSeconds _waitForSeconds;

	private void Awake()
	{
		_monsterController = GetComponent<MonsterController>();
		_waitForSeconds = new WaitForSeconds(1f);
		_collider = GetComponent<Collider2D>();
		_animaotr = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		StartCoroutine(Think());
	}

	void Update()
	{
		LookPlayer();
	}

	void LookPlayer()
	{
		if (_monsterController.isLive == false)
		{
			DIRECTION = (_player.GetComponent<Transform>().position.x < transform.position.x ? -1 : 1);
			float scale = transform.localScale.z;
			transform.localScale = new Vector3(DIRECTION * -1 * scale, scale, scale);
		}
	}

	IEnumerator Think()
	{
		if (_monsterController.isLive == false && PlayerController.isDie == false)
		{
			yield return new WaitForSeconds(1f);

			int ranAction = Random.Range(0, 6);

			switch (ranAction)
			{
				case 0:
				case 1:
				case 2:
					StartCoroutine(Move());
					break;
				case 3:
				case 4:
					StartCoroutine(Attack());
					break;
				case 5:
					StartCoroutine(JumpAttack());
					break;
				default:
					break;
			}
		}
		else
		{
			_rigid.velocity = Vector2.zero;
		}
	}

	IEnumerator Move()
	{
		_animaotr.SetTrigger("JumpReady");
		yield return new WaitForSeconds(0.5f);

		_animaotr.SetTrigger("JumpMove");
		Vector2 startPos = transform.position;
		Vector2 targetPos = _player.transform.position;
		_collider.enabled = false;

		float elapsedTime = 0f;
		float jumpTime = 1f;

		while (elapsedTime < jumpTime)
		{
			float time = elapsedTime / jumpTime;
			transform.position = Vector2.Lerp(startPos, targetPos, time);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		transform.position = targetPos;
		_collider.enabled = true;
		_animaotr.SetTrigger("MoveEnd");

		yield return _waitForSeconds;
		StartCoroutine(Think());
	}

	IEnumerator Attack()
	{
		_animaotr.SetTrigger("Shot");
		yield return new WaitForSeconds(0.5f);

		yield return _waitForSeconds;
		StartCoroutine(Think());
	}

	IEnumerator JumpAttack()
	{
		_animaotr.SetTrigger("JumpReady");
		yield return new WaitForSeconds(0.5f);

		_animaotr.SetTrigger("JumpUp");
		_rigid.velocity = new Vector2(0, 50f);
		_collider.enabled = false;
		Vector2 playerPos = _player.transform.position;

		while (true)
		{
			if (transform.position.y >= 50f)
			{
				_animaotr.SetTrigger("JumpDown");
				_rigid.velocity = Vector2.zero;
				_collider.enabled = true;
				break;
			}
			yield return null;
		}

		_animaotr.SetTrigger("JumpEnd");
		transform.position = new Vector2(playerPos.x, playerPos.y);

		yield return _waitForSeconds;
		StartCoroutine(Think());
	}

	void Attacks()
	{
		Vector2 direction = (_player.position - _shotPoint.position).normalized;

		for (int i = 0; i < numberOfTears; i++)
		{
			direction = Quaternion.Euler(0, 0, Random.Range(-30, 30)) * (_player.position - _shotPoint.position).normalized;
			Transform bloodTears = GameManager._instance._pool.Get(1).transform;
			bloodTears.position = _shotPoint.position;
			Rigidbody2D rigid = bloodTears.GetComponent<Rigidbody2D>();
			rigid.velocity = direction * tearSpeed; // 총알 속도 설정
		}
	}

	private void OnEnable()
	{
		//_player = GameManager._instance._player.GetComponent<Transform>();
	}
}

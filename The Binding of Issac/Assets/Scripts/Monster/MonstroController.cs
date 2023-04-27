using System.Collections;
using UnityEngine;

public class MonstroController : MonoBehaviour
{
	private int DIRECTION = -1;
	private int shotSpeed = 10;
	private float speed = 10f;

	public GameObject _tearsPrefabs;
	public Rigidbody2D _player;
	public Transform _shotPoint;
	private Rigidbody2D _rigid;
	private Animator _animaotr;
	private Collider2D _collider;
	MonsterController _monsterController;
	WaitForSeconds _waitForSeconds;

	private void Awake()
	{
		_waitForSeconds = new WaitForSeconds(1f);
		_collider = GetComponent<Collider2D>();
		_animaotr = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody2D>();
		_monsterController = GetComponent<MonsterController>();
	}

	void Start()
	{
		StartCoroutine(Move());
	}

	void Update()
	{
		LookPlayer();
	}

	void LookPlayer()
	{
		DIRECTION = (_player.GetComponent<Transform>().position.x < transform.position.x ? -1 : 1);
		float scale = transform.localScale.z;
		transform.localScale = new Vector3(DIRECTION * -1 * scale, scale, scale);
	}

	IEnumerator Think()
	{

		yield return new WaitForSeconds(1f);

		int ranAction = Random.Range(0, 5);

		switch (ranAction)
		{
			case 0:
			case 1:
			case 2:
				StartCoroutine(Move());
				break;
			case 3:
				StartCoroutine(JumpAttack());
				break;
			case 4:
				StartCoroutine(Attack());
				break;
			default:
				break;
		}

	}

	IEnumerator Move()
	{
		_animaotr.SetTrigger("JumpReady");
		yield return new WaitForSeconds(0.5f);

		_animaotr.SetTrigger("JumpMove");
		Vector2 startPos = transform.position;
		Vector2 targetPos = _player.transform.position;

		float elapsedTime = 0f;
		float jumpTime = 1f;

		while (elapsedTime < jumpTime)
		{
			float t = elapsedTime / jumpTime;
			transform.position = Vector2.Lerp(startPos, targetPos, t);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		transform.position = targetPos;
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
	}

	private void OnEnable()
	{
		// _player = GameManager._instance._player.GetComponent<RigidBody2D>();
	}
}

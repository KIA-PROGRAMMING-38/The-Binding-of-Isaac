using System.Collections;
using UnityEngine;


public class MonstroController : MonoBehaviour
{
	private int DIRECTION = -1;
	private int shotSpeed = 10;
	private float speed = 5f;

	public GameObject _tearsPrefabs;
	public GameObject _player;
	public Transform _shotPoint;
	private Rigidbody2D _rigid;
	private Animator _animaotr;
	private Collider2D _collider;

	private void Awake()
	{
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
		DIRECTION = (_player.GetComponent<Transform>().position.x < transform.position.x ? -1 : 1);
		float scale = transform.localScale.z;
		transform.localScale = new Vector3(DIRECTION * -1 * scale, scale, scale);
	}

	IEnumerator Think()
	{
		yield return new WaitForSeconds(1f);

		int ranAction = Random.Range(0, 3);

		switch (ranAction)
		{
			case 0:
			case 1:
				//StartCoroutine(Attack());
				break;
			case 2:
				StartCoroutine(JumpAttack());
				break;
			default:
				break;
		}
	}

	//IEnumerator Attack()
	//{
		
	//}

	IEnumerator JumpAttack()
	{
		LookPlayer();
		_animaotr.SetTrigger("JumpReady");

		yield return new WaitForSeconds(0.5f);

		Vector2 playerPos = _player.transform.position;

		_rigid.velocity = new Vector2(0, 50f);
	    _collider.enabled = false;
		_animaotr.SetTrigger("JumpUp");

		transform.position = new Vector2(playerPos.x, playerPos.y);

		while (true)
		{
			if (transform.position.y >= 50f)
			{
				_animaotr.SetTrigger("JumpDown");
				_rigid.velocity = Vector2.zero;
				_collider.enabled = true;
				break;
			}
			yield return new WaitForSeconds(1f);
		}

		transform.position = new Vector2(playerPos.x, playerPos.y);
		_animaotr.SetTrigger("JumpEnd");

		StartCoroutine(Think());
	}
}

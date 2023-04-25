using UnityEngine;

public class TearsShoot : MonoBehaviour
{
	public float shotSpeed;
	public float tearSpeed = 2f;
	public float tearRange;

	public Tears _tearsPrefabs;
	Animator _animator;

	public Vector2[] _directions = { Vector2.down, Vector2.up, Vector2.right, Vector2.left };
	public int directionsIndex = -1;

	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		Shoot();
	}

	void FireTear()
	{
		Transform tears = GameManager._instance._pool.Get(0).transform;
		Rigidbody2D rigid = tears.GetComponent<Rigidbody2D>();
		Vector2 direction = _directions[directionsIndex];
		rigid.AddForce(direction * shotSpeed, ForceMode2D.Impulse);
		tears.transform.position = transform.position;
	}

	void Shoot()
	{
		_animator.SetFloat("AttackSpeed", tearSpeed);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			directionsIndex = 3;
			_animator.SetBool("leftFire", true);
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
}

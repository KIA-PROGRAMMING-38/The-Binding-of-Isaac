using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
	public float moveSpeed = 1f;
	private Vector2 movement;
	private float timer;

	private Rigidbody2D _rigid;
	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		movement = Vector2.up;
		timer = 0.5f;
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			timer = 0.5f;
			ChangeDirection();
		}
	}

	void FixedUpdate()
	{
		_rigid.MovePosition(_rigid.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

	void ChangeDirection()
	{
		int direction = Random.Range(0, 4);
		switch (direction)
		{
			case 0:
				movement = Vector2.up;
				_animator.SetBool("LeftMove", false);
				_animator.SetBool("RightMove", false);
				break;
			case 1:
				movement = Vector2.down;
				_animator.SetBool("LeftMove", false);
				_animator.SetBool("RightMove", false);
				break;
			case 2:
				movement = Vector2.left;
				_animator.SetBool("LeftMove", true);
				_animator.SetBool("RightMove", false);
				break;
			case 3:
				movement = Vector2.right;
				_animator.SetBool("RightMove", true);
				_animator.SetBool("LeftMove", false);
				break;
		}
	}
}

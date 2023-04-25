using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{
	public float speed;

	public Rigidbody2D target;

	Rigidbody2D _rigid;

	private void Awake()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		target.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
	}

	private void FixedUpdate()
	{
		// �÷��̾� ����(���� �ؾߵ�)
		Vector2 dirVec = target.position - _rigid.position;
		Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
		_rigid.MovePosition(_rigid.position + nextVec);
		_rigid.velocity = Vector2.zero;
	}
}

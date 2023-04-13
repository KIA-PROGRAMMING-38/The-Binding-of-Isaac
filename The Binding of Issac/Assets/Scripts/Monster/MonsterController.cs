using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
	public float speed;
	bool isLive;

	// public Rigidbody2D target;
	Rigidbody2D _rigid;

	private void Awake()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		// 플레이어 추적 (수정 해야됨)
		//Vector2 dirVec = target.position - _rigid.position;
		//Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
		//_rigid.MovePosition(_rigid.position + nextVec);
		//_rigid.velocity = Vector2.zero;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerController player = collision.gameObject.GetComponent<PlayerController>();

		if (player != null)
		{
			player.SetHealth(-1);
		}
	}
}

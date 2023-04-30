using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{
	public float speed;

	public Rigidbody2D _target;

	Rigidbody2D _rigid;

	private void Awake()
	{
		_rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (PlayerController.isDie == false)
		{
			// 플레이어 추적(수정 해야됨)
			Vector2 dirVec = _target.position - _rigid.position;
			Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
			_rigid.MovePosition(_rigid.position + nextVec);
			_rigid.velocity = Vector2.zero;
		}
	}

	private void OnEnable()
	{
		_target = GameManager._instance._player.GetComponent<Rigidbody2D>();
	}
}

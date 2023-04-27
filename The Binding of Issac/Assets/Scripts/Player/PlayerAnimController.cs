using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerAnimID
{
	public static readonly int LEFT_WALK = Animator.StringToHash("leftWalk");
	public static readonly int RIGHT_WALK = Animator.StringToHash("rightWalk");
	public static readonly int WALK = Animator.StringToHash("Walk");
	public static readonly int LOOK_LEFT = Animator.StringToHash("lookLeft");
	public static readonly int LOOK_RIGHT = Animator.StringToHash("lookRight");
	public static readonly int LOOK_UP = Animator.StringToHash("lookUp");
	public static readonly int LOOK_DOWN = Animator.StringToHash("lookDown");
	public static readonly int Get_Item = Animator.StringToHash("GetItem");
}

public class PlayerAnimController : MonoBehaviour
{
	[SerializeField]
	Animator _animatorHead;
	[SerializeField]
	Animator _animatorBody;

	void Update()
    {
		PlayerMovement();
		PlayerLookAt();
	}

	// 플레이어의 이동 방향에 따른 걷기 애니메이션 변경 기능
	void PlayerMovement()
	{
		if (Input.GetKey(KeyCode.A))
			_animatorBody.SetBool(PlayerAnimID.LEFT_WALK, true);
		else if (Input.GetKeyUp(KeyCode.A))
			_animatorBody.SetBool(PlayerAnimID.LEFT_WALK, false);

		if (Input.GetKey(KeyCode.D))
			_animatorBody.SetBool(PlayerAnimID.RIGHT_WALK, true);
		else if (Input.GetKeyUp(KeyCode.D))
			_animatorBody.SetBool(PlayerAnimID.RIGHT_WALK, false);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			_animatorBody.SetBool(PlayerAnimID.WALK, true);
		else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			_animatorBody.SetBool(PlayerAnimID.WALK, false);
	}

	// 플레이어의 이동 방향에 따른 바라보는 애니메이션 변경 기능
	void PlayerLookAt()
	{
		if (Input.GetKey(KeyCode.A))
			_animatorHead.SetBool(PlayerAnimID.LOOK_LEFT, true);
		else if (Input.GetKeyUp(KeyCode.A))
			_animatorHead.SetBool(PlayerAnimID.LOOK_LEFT, false);

		if (Input.GetKey(KeyCode.D))
			_animatorHead.SetBool(PlayerAnimID.LOOK_RIGHT, true);
		else if (Input.GetKeyUp(KeyCode.D))
			_animatorHead.SetBool(PlayerAnimID.LOOK_RIGHT, false);

		if (Input.GetKey(KeyCode.W))
			_animatorHead.SetBool(PlayerAnimID.LOOK_UP, true);
		else if (Input.GetKeyUp(KeyCode.W))
			_animatorHead.SetBool(PlayerAnimID.LOOK_UP, false);

		if (Input.GetKey(KeyCode.S))
			_animatorHead.SetBool(PlayerAnimID.LOOK_DOWN, true);
		else if (Input.GetKeyUp(KeyCode.S))
			_animatorHead.SetBool(PlayerAnimID.LOOK_DOWN, false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Items"))
			_animatorHead.SetTrigger(PlayerAnimID.Get_Item);
	}
}

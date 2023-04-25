using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
			_animatorBody.SetBool("leftWalk", true);
		else if (Input.GetKeyUp(KeyCode.A))
			_animatorBody.SetBool("leftWalk", false);

		if (Input.GetKey(KeyCode.D))
			_animatorBody.SetBool("rightWalk", true);
		else if (Input.GetKeyUp(KeyCode.D))
			_animatorBody.SetBool("rightWalk", false);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			_animatorBody.SetBool("Walk", true);
		else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			_animatorBody.SetBool("Walk", false);
	}

	// 플레이어의 이동 방향에 따른 바라보는 애니메이션 변경 기능
	void PlayerLookAt()
	{
		if (Input.GetKey(KeyCode.A))
			_animatorHead.SetBool("lookLeft", true);
		else if (Input.GetKeyUp(KeyCode.A))
			_animatorHead.SetBool("lookLeft", false);

		if (Input.GetKey(KeyCode.D))
			_animatorHead.SetBool("lookRight", true);
		else if (Input.GetKeyUp(KeyCode.D))
			_animatorHead.SetBool("lookRight", false);

		if (Input.GetKey(KeyCode.W))
			_animatorHead.SetBool("lookUp", true);
		else if (Input.GetKeyUp(KeyCode.W))
			_animatorHead.SetBool("lookUp", false);

		if (Input.GetKey(KeyCode.S))
			_animatorHead.SetBool("lookDown", true);
		else if (Input.GetKeyUp(KeyCode.S))
			_animatorHead.SetBool("lookDown", false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Items"))
			_animatorHead.SetTrigger("GetItem");
	}
}

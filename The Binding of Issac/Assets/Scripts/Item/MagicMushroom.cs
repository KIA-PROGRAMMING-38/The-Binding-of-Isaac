using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroom : MonoBehaviour
{
	float attackValue = 1;
	TearsShoot _tearShoot;

	private void Awake()
	{
		_tearShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
	}

	// 모든 능력치 증가 + 플레이어 크기 증가
	private void OnTriggerEnter2D(Collider2D collision)
	{ 
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
			if (playerController != null && _tearShoot != null)
			{
				playerController.SetCurrnetMaxHealth(1);
				playerController.attackPower += attackValue;
				playerController.moveSpeed += 0.5f;
				playerController.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				_tearShoot.tearSpeed += 0.5f;
				_tearShoot.tearRange += 0.5f;
				_tearShoot.shotSpeed += 1f;
				Destroy(gameObject);
			}
		}
	}
}

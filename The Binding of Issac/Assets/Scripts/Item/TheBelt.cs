using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBelt : MonoBehaviour
{
	// 이동속도 증가
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
			if (playerController != null)
			{
				playerController.moveSpeed += 1;
				Destroy(gameObject);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigmata : MonoBehaviour
{
	float attackValue = 1;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();

			if (playerController != null)
			{
				playerController.SetCurrnetMaxHealth(1);
				playerController.attackPower += attackValue;
				Destroy(gameObject);
			}
		}
	}
}

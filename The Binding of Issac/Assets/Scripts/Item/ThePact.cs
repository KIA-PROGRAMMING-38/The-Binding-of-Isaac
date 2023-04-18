using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePact : MonoBehaviour
{
	float attackValue = 1;
	TearsShoot _tearShoot;

	private void Awake()
	{
		_tearShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
			if (playerController != null && _tearShoot != null)
			{
				playerController.attackPower += attackValue;
				_tearShoot.tearSpeed += 0.5f;
				Destroy(gameObject);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
			if (playerController != null)
			{
				// ��ź +99;
			}
		}
	}
}

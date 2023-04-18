using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Squeezy : MonoBehaviour
{
	TearsShoot _tearShoot;

	private void Awake()
	{
		_tearShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
	}

	// 공격속도 증가
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (_tearShoot != null)
			{
				_tearShoot.tearSpeed += 0.5f;
				Destroy(gameObject);
			}
		}
	}
}
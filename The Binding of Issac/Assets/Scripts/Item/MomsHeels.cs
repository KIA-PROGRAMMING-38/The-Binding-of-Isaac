using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomsHeels : MonoBehaviour
{
	TearsShoot _tearShoot;

	private void Awake()
	{
		_tearShoot = GameObject.Find("Isaac_Head").GetComponent<TearsShoot>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (_tearShoot != null)
			{
				_tearShoot.tearRange += 1f;
				Destroy(gameObject);
			}
		}
	}
}

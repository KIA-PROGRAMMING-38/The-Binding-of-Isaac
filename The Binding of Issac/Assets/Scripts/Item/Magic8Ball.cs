using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic8Ball : MonoBehaviour
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
				_tearShoot.shotSpeed += 1f;
				Destroy(gameObject);
			}
		}
	}
}

using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
			if (playerController != null)
			{
				playerController.SetHealth(-1);
			}
		}
	}
}


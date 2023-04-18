using UnityEngine;

public class Heart : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log($"{collision.gameObject.name}");
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();

			if (playerController != null)
			{
				playerController.SetCurrnetMaxHealth(1);
				Destroy(gameObject);
			}
		}
	}
}

using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	PlayerDamaged _playerDamaged;
	[SerializeField] private int _damage;

	private void Awake()
	{
		_playerDamaged = GameObject.Find("PlayerHitBox").GetComponent<PlayerDamaged>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && _playerDamaged.isInvincibleTime == false)
		{
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

			if (playerController != null)
			{
				if (playerController.currentHealth > _damage)
				{
					_playerDamaged.PlayHitAnim();
					_playerDamaged.isInvincibleTime = true;
					StartCoroutine(_playerDamaged.InvincibleTime());
				}
				playerController.SetHealth(-_damage);
			}
		}
	}
}


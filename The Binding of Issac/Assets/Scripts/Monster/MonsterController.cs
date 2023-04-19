using UnityEngine;

public class MonsterController : MonoBehaviour
{
	public float health;

	PlayerController _playerController;

	private void Awake()
	{
		_playerController = GameObject.Find("Isaac_Body").GetComponent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("tears"))
		{
			if (_playerController != null)
			{
				health -= _playerController.attackPower;
				Debug.Log(health);
			}
		}
	}
}

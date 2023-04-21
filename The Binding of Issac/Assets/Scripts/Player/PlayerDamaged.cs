using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _head;
	[SerializeField]
	private SpriteRenderer _body;
	[SerializeField]
	private GameObject _headObject;
    private Animator _headAnimator;

	public bool isInvincibleTime;

	private void Awake()
	{
		_headAnimator = _headObject.GetComponent<Animator>();
	}

	public IEnumerator InvincibleTime()
	{
		int countTime = 0;

		while (countTime < 12)
		{
			if (countTime % 2 == 0)
			{
				_head.color = new Color32(255, 255, 255, 90);
				_body.color = new Color32(255, 255, 255, 90);
			}
			else
			{
				_head.color = new Color32(255, 255, 255, 180);
				_body.color = new Color32(255, 255, 255, 180);
			}

			yield return new WaitForSeconds(0.1f);

			countTime++;
		}

		_head.color = new Color32(255, 255, 255, 255);
		_body.color = new Color32(255, 255, 255, 255);

		isInvincibleTime = false;

		yield return null;
	}

	public void PlayHitAnim()
	{
		_headAnimator.SetTrigger("PlayerHit");
	}
}

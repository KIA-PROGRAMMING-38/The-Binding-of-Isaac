using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public SpriteRenderer _head;
    public SpriteRenderer _body;
    public GameObject _headObject;
    private Animator _headAnimator;

	private void Awake()
	{
		_headAnimator = _headObject.GetComponent<Animator>();
	}
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Enemy"))
        {
			OnDamaged();
		}
    }

    void OnDamaged()
    {
        _head.color = new Color(1, 1, 1, 0.4f);
        _body.color = new Color(1, 1, 1, 0.4f);

        _headAnimator.SetTrigger("PlayerHit");
	}
}

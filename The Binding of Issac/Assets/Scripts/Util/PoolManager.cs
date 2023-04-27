using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	public GameObject[] _prefabs;

	List<GameObject>[] _pools;

	private void Awake()
	{
		_pools = new List<GameObject>[_prefabs.Length];

		for (int index = 0; index < _pools.Length; index++)
		{
			_pools[index] = new List<GameObject>();
		}
	}

	public GameObject Get(int index)
	{
		GameObject select = null;

		// 선택한 풀에 비활성화 된 게임오브젝트 접근
		foreach (GameObject pool in _pools[index])
		{
			if (!pool.activeSelf)
			{
				select = pool;
				select.SetActive(true);
				break;
			}
		}

		// 못 찾았다면
	    if (!select)
		{
			// 새롭게 생성하고 select 변수에 할당
			select = Instantiate(_prefabs[index], transform);
			_pools[index].Add(select);
		}
		return select;
	}
}

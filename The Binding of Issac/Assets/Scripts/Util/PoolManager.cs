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

		// ������ Ǯ�� ��Ȱ��ȭ �� ���ӿ�����Ʈ ����
		foreach (GameObject pool in _pools[index])
		{
			if (!pool.activeSelf)
			{
				select = pool;
				select.SetActive(true);
				break;
			}
		}

		// �� ã�Ҵٸ�
	    if (!select)
		{
			// ���Ӱ� �����ϰ� select ������ �Ҵ�
			select = Instantiate(_prefabs[index], transform);
			_pools[index].Add(select);
		}
		return select;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki1 : MonoBehaviour
{
	[SerializeField]
	GameObject prefab;

	int count = 0;
	int max = 100;

	void Start()
	{
		InvokeRepeating("Generate", 1, 1);
		for (count = 0; count < 5; count++)
		{
			float x = Random.Range(0f, 9f);
			float y = Random.Range(0f, 9f);
			float z = 0;
			Vector3 position = new Vector3(x, y, z);
			Instantiate(prefab, position, Quaternion.identity);
		}
	}	
	void Generate()
	{
		if (count == max) return;
		{
			float x = Random.Range(-50f, 50f);
			float y = Random.Range(0f, 50f);
			float z = 0;
			Vector3 position = new Vector3(x, y, z);
			Instantiate(prefab, position, Quaternion.identity);
			count++;
		}
	}
}


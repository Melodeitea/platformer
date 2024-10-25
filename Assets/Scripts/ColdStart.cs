using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdStart : MonoBehaviour
{
	[SerializeField] GameObject loadManagerPrefab;
	private static bool isInit = false;

	// Start is called before the first frame update
	void Start()
	{
		if (isInit)
			return;

		Instantiate(loadManagerPrefab, null);
		isInit = true;
	}
		
}

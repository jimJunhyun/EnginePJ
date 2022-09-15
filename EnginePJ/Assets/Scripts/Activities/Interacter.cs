using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public float interDist;
    public int useLayer = 7;

	private void Awake()
	{
		useLayer = 1 << useLayer;
	}

	// Update is called once per frame
	void Update()
    {
		if (CursorManager.instance.col && Input.GetMouseButtonDown(0))
		{
			
		}
    }
}

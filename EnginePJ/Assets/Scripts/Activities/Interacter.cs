using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public float interDist;
    public int useLayer = 7;

	RaycastHit2D hit;

	private void Awake()
	{
		useLayer = 1 << useLayer;
	}

	// Update is called once per frame
	void Update()
    {
		if (CursorManager.instance.col && Input.GetMouseButtonDown(0))
		{
			if(hit = Physics2D.Raycast(transform.position, (CursorManager.instance.col.transform.position - transform.position ).normalized, interDist, useLayer))
			{
				hit.transform.GetComponent<Interacts>().Act();
			}
		}
    }
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, interDist);
	}
}
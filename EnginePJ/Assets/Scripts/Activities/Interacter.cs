using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public float interDist;
    public int useLayer = 7;

	Animator myAnim;

	RaycastHit2D hit;

	private void Awake()
	{
		useLayer = 1 << useLayer;
		myAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
    {
		if (CursorManager.instance.col && Input.GetMouseButtonDown(0))
		{
			Debug.Log("!");
			if (hit = Physics2D.Raycast(transform.position, (CursorManager.instance.col.transform.position - transform.position ).normalized, interDist, useLayer))
			{
				hit.transform.GetComponent<Interacts>().Act(()=>{ myAnim.SetBool("Interacting", false); });
				
				myAnim.SetBool("Interacting", true);
				myAnim.SetBool("Walking", false);
				myAnim.SetBool("Idling", false);

			}
		}
    }
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, interDist);
	}
}
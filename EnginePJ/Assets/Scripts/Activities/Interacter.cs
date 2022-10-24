using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public float interDist;

	Animator myAnim;

	RaycastHit2D hit;

	private void Awake()
	{
		myAnim = GetComponent<Animator>();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, interDist);
	}

	public void TempFL()
	{
		Debug.Log("봤습니다.");
	}

	public void TempFO()
	{
		Debug.Log("얻었습니다.");
	}
}
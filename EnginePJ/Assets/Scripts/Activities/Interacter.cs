using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public float interDist;

	Animator myAnim;
	PlayerSpeak speak;

	RaycastHit2D hit;

	private void Awake()
	{
		myAnim = GetComponent<Animator>();
		speak = GetComponent<PlayerSpeak>();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, interDist);
	}

	public void Looker(string log)
	{
		speak.Show(log);
	}

	public void TempFO()
	{
		Debug.Log("얻었습니다.");
	}
}
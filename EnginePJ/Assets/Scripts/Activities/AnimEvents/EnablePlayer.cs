using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
	SpriteRenderer rend;
	SpriteRenderer pRend;
	Animator anim;
	private void Start()
	{
		try
		{
			rend = GetComponent<SpriteRenderer>();
			pRend = PlayerCtrl.instance.GetComponent<SpriteRenderer>();
			anim = GetComponent<Animator>();
			anim.enabled = false;
		}
		catch(System.NullReferenceException nullDetected)
		{
			Debug.Log($"초기화 실패. {nullDetected.Message}");
		}
	}
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			anim.enabled = true;
		}
	}
	public void UngrantPlayer()
	{
		PlayerCtrl.instance.enabled = false;
		rend.enabled = true;
		pRend.enabled = false;
	}
	public void GrantPlayer()
	{
		PlayerCtrl.instance.enabled = true;
		rend.enabled = false;
		pRend.enabled = true;
	}
	public void DelayGrant(float d)
	{
		StartCoroutine(DelayCtrl(d, true));
	}
	public void DelayUnGrant(float d)
	{
		StartCoroutine(DelayCtrl(d, false));
	}
	IEnumerator DelayCtrl(float d, bool grant)
	{
		yield return new WaitForSeconds(d);
		if (grant)
		{
			GrantPlayer();
		}
		else
		{
			UngrantPlayer();
		}
	}
}

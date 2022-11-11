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
			Debug.Log($"�ʱ�ȭ ����. {nullDetected.Message}");
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
}

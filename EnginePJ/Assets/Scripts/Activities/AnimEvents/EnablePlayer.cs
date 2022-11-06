using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
	SpriteRenderer rend;
	SpriteRenderer pRend;
	private void Start()
	{
		rend = GetComponent<SpriteRenderer>();
		pRend = PlayerCtrl.instance.GetComponent<SpriteRenderer>();
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

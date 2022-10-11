using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CinemaDirector : MonoBehaviour
{
	public static CinemaDirector instance;
	public List<UnityEvent> dircs;

	public int processes =0;

	UpdateLights lightMan;
	ShowTxtOnDark textMan;
	MoveToPos moveMan;
	Conversation convMan;
	CameraTransition tranMan;

	int idx = 0;
	bool nextProceed = false;
	bool clicked;

	private void Awake()
	{
		instance = this;
		lightMan = GetComponent<UpdateLights>();
		textMan = GetComponent<ShowTxtOnDark>();
		moveMan = GetComponent<MoveToPos>();
		convMan = GetComponent<Conversation>();
		tranMan = GetComponent<CameraTransition>();
	}

	private void Update()
	{
		if (((idx == 0 || processes == 0 || clicked) && idx < dircs.Count))
		{
			clicked = false;
			dircs[idx].Invoke();
			++idx;
		}
	}
	public void WaitClick()
	{
		StartCoroutine(ClickDetect());
	}
	IEnumerator ClickDetect()
	{
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		clicked = true;
	}

}

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

	int idx = 0;
	bool clicked;

	Conversation convMan;

	private void Awake()
	{
		instance = this;
		convMan = GetComponent<Conversation>();
	}

	private void Update()
	{
		if (((idx == 0 || processes == 0 || clicked) && idx < dircs.Count))
		{
			clicked = false;
			processes = 0;
			dircs[idx].Invoke();
			++idx;
		}
	}
	public void WaitClick()
	{
		processes += 1;
		StartCoroutine(ClickDetect());
	}
	IEnumerator ClickDetect()
	{
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		clicked = true;
		convMan.OffBallon();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// ¿Ï·á
/// </summary>
public class ShowTxtOnDark : MonoBehaviour
{
	public bool isComp;
	public Image DarkPanel;
    public TextMeshProUGUI txt;

	public Vector3 dels;

	private void Awake()
	{
		txt.text = "";
	}
	public void EmptyFunc()
	{
		isComp = true;
	}
	public void DelEmpFunc(float t)
	{
		StartCoroutine(DelayEmpty(t));
	}

	public void FadeAppear(float time)
	{
		StartCoroutine(DelayFade(time, 1));
	}

	public void FadeDisappear(float time)
	{
		StartCoroutine(DelayFade(time, 0));
	}

	public void Show(string txt)
	{
        StartCoroutine(DelayShowDelay(txt));
	}

	public void Erase(int leaveLen)
	{
		StartCoroutine(Eraser(leaveLen));
	}

	public void SetPreDel(float val)
	{
		dels.x = val;
		isComp = true;
	}
	public void SetMidDel(float val)
	{
		dels.y = val;
		isComp = true;
	}
	public void SetPostDel(float val)
	{
		dels.z = val;
		isComp = true;
	}
	IEnumerator DelayEmpty(float t)
	{
		yield return new WaitForSeconds(t);
		isComp = true;
	}
	IEnumerator Eraser(int leftTxtLen)
	{
		int initLen = txt.text.Length;
		yield return new WaitForSeconds(dels.x);
		for (int i = 0; i < initLen - leftTxtLen; i++)
		{
			txt.text = txt.text.Substring(0, txt.text.Length - 1);
			yield return new WaitForSeconds(dels.y);
		}
		yield return new WaitForSeconds(dels.z);
		isComp = true;
	}

    IEnumerator DelayShowDelay(string shower)
	{
        yield return new WaitForSeconds(dels.x);
		for (int i = 0; i < shower.Length; i++)
		{
            txt.text += shower[i];
			yield return new WaitForSeconds(dels.y);
		}
		yield return new WaitForSeconds(dels.z);
		isComp = true;
	}

	IEnumerator DelayFade(float time, float onoff)
	{
		float timePassed = 0;
		Color initC = DarkPanel.color;
		while (timePassed <= time)
		{
			yield return null;
			timePassed += Time.deltaTime;
			Color c = DarkPanel.color;
			c.a = Mathf.Lerp(initC.a, onoff, timePassed / time);
			DarkPanel.color = c;
		}
		yield return null;
		isComp = true;
	}
}

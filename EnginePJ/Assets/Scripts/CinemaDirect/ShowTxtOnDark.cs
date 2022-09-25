using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
	}
	public void SetMidDel(float val)
	{
		dels.y = val;
	}
	public void SetPostDel(float val)
	{
		dels.z = val;
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
}

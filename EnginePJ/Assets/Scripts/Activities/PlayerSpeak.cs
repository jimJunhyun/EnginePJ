using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerSpeak : MonoBehaviour
{
    public float typeMidDel;

	TextMeshProUGUI sayText;
	Image wordBallon;

	private void Awake()
	{
		wordBallon = GetComponentInChildren<Image>();
		sayText = GetComponentInChildren<TextMeshProUGUI>();
	}
	private void Update()
	{
		if(transform.localScale.x < 0)
		{
			wordBallon.rectTransform.rotation = Quaternion.Euler(0, -180,0);
		}
		else
		{
			wordBallon.rectTransform.rotation = Quaternion.identity;
		}
	}
	public void Show(string txt)
	{
		StartCoroutine(DelShow(txt));
	}
	public void ShowSeq(List<string> scripts, UnityAction onComp)
	{
		StartCoroutine(SequenceShow(scripts, onComp));
	}
	IEnumerator SequenceShow(List<string> scrs, UnityAction onComp)
	{
		wordBallon.enabled = true;
		PlayerCtrl.instance.DeMove();
		string buffer = "";
		for (int i = 0; i < scrs.Count; i++)
		{
			sayText.text = "";
			buffer = "";
			int strIdx = 0;
			while (strIdx < scrs[i].Length)
			{
				yield return new WaitForSeconds(typeMidDel);
				buffer += scrs[i][strIdx];
				++strIdx;
				sayText.text = buffer;
			}
			yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
		}
		PlayerCtrl.instance.GoMove();
		onComp.Invoke();
		wordBallon.enabled = false;
		sayText.text = "";
	}
    IEnumerator DelShow(string txt)
	{
		wordBallon.enabled = true;
		sayText.text = "";
		PlayerCtrl.instance.DeMove();
		string buffer= "";
		int idx = 0;
		while(idx < txt.Length)
		{
			yield return new WaitForSeconds(typeMidDel);
			buffer += txt[idx];
			++idx;
			sayText.text = buffer;
		}
		yield return new WaitForSeconds(0.5f);
		yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0);});
		PlayerCtrl.instance.GoMove();
		wordBallon.enabled = false;
		sayText.text = "";
	}
}

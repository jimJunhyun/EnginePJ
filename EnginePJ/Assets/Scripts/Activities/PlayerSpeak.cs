using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	public void Show(string txt)
	{
		StartCoroutine(DelShow(txt));
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
		Debug.Log("Wrote" + buffer);
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0);});
		Debug.Log("Erase");
		PlayerCtrl.instance.GoMove();
		wordBallon.enabled = false;
		sayText.text = "";
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// 캐릭터 위에 대사를 말풍선으로 띄워야함.
/// 말풍선 UI와 대사는 임시
/// 캐릭터 위치가 필요?
/// 
/// </summary>
public class Conversation : MonoBehaviour
{
    public bool isComp;
    public List<Transform> sayers;
    public List<string> wordScripts;
    public Vector3 dels;

    Image wordBallon;
    TextMeshProUGUI word;

    
    
    int idx = 0;

	public void EmptyFunc()
	{
		isComp = true;
	}
    public void DelEmpFunc(float t)
    {
        StartCoroutine(DelayEmpty(t));
    }

    public void SetPreDel(float x)
	{
        dels.x = x;
        isComp = true;
    }
    public void SetMidDel(float y)
    {
        dels.y = y;
        isComp = true;
    }
    public void SetPostDel(float z)
    {
        dels.z = z;
        isComp = true;
    }
    public void NextSerif()
	{
        StartCoroutine(DelaySerif());
	}
    IEnumerator DelayEmpty(float t)
    {
        yield return new WaitForSeconds(t);
        isComp = true;
    }
    IEnumerator DelaySerif()
	{
        wordBallon = sayers[idx].GetComponentInChildren<Image>();
        word = wordBallon.GetComponentInChildren<TextMeshProUGUI>();
        wordBallon.enabled = true;
        word.text = "";
        yield return new WaitForSeconds(dels.x);
		for (int i = 0; i < wordScripts[idx].Length; i++)
		{
            yield return new WaitForSeconds(dels.y);
            word.text += wordScripts[idx][i];
		}
        yield return new WaitForSeconds(dels.z);
        wordBallon.enabled = false;
        word.text = "";
        ++idx;
        isComp = true;
	}
}

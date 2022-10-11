using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// ĳ���� ���� ��縦 ��ǳ������ �������.
/// ��ǳ�� UI�� ���� �ӽ�
/// ĳ���� ��ġ�� �ʿ�?
/// 
/// </summary>
public class Conversation : MonoBehaviour
{
    public List<Transform> sayers;
    public List<string> wordScripts;
    public Vector3 dels;

    Image wordBallon;
    TextMeshProUGUI word;

    
    
    int idx = 0;

    public void SetPreDel(float x)
	{
        dels.x = x;
    }
    public void SetMidDel(float y)
    {
        dels.y = y;
    }
    public void SetPostDel(float z)
    {
        dels.z = z;
    }
    public void NextSerif()
	{
        CinemaDirector.instance.processes += 1;
        StartCoroutine(DelaySerif());
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
        
        CinemaDirector.instance.processes -= 1;
	}
}

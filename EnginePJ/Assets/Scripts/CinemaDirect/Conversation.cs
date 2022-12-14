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
    public List<Transform> sayers;
    public List<string> wordScripts;
    public Vector3 dels;

    Image wordBallon;
    TextMeshProUGUI word;
    Animator talkerAnim;
    
    
    int idx = 0;

	private void Awake()
	{
        wordBallon = sayers[idx].GetComponentInChildren<Image>();
        word = wordBallon.GetComponentInChildren<TextMeshProUGUI>();
    }

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
		if (talkerAnim = sayers[idx].GetComponentInChildren<Animator>())
		{
            talkerAnim.SetTrigger("Talking");
		}
		for (int i = 0; i < wordScripts[idx].Length; i++)
		{
            yield return new WaitForSeconds(dels.y);
            word.text += wordScripts[idx][i];
		}
        yield return new WaitForSeconds(dels.z);
        CinemaDirector.instance.WaitClick();
        CinemaDirector.instance.processes -= 1;
	}
    public void OffBallon()
	{
		if (wordBallon.enabled)
		{
            wordBallon.enabled = false;
            word.text = "";
            ++idx;
        }
        
    }
}

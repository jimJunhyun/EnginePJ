using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTxtOnDark : MonoBehaviour
{
    public Image DarkPanel;
    public Text txt;
    public string showText;

	private void Awake()
	{
		txt.text = "";
	}

	public void Show(Vector3 dels)
	{
        StartCoroutine(DelayShowDelay(dels));
	}

    IEnumerator DelayShowDelay(Vector3 dels)
	{
        yield return new WaitForSeconds(dels.x);
		for (int i = 0; i < showText.Length; i++)
		{
            txt.text += showText[i];
			yield return new WaitForSeconds(dels.y);
		}
		yield return new WaitForSeconds(dels.z);
	}
}

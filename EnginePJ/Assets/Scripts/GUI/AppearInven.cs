using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AppearInven : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	Image invenPanel;
	RectTransform myRect;
	Vector2 onPos;
	Vector2 offPos;

	public float lerpTime;
	public float lerpDist;
	private void Awake()
	{
		myRect = GetComponent<RectTransform>();
		invenPanel = GetComponentsInChildren<Image>()[1];
		offPos = invenPanel.rectTransform.anchoredPosition;
		onPos = Vector2.zero;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		StopAllCoroutines();
		StartCoroutine(LerpPanel(1));
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopAllCoroutines();
		StartCoroutine(LerpPanel(-1));
	}

	IEnumerator LerpPanel(int dir)
	{
		float curTime = 0;
		Vector2 initPos = invenPanel.rectTransform.anchoredPosition;
		while (curTime < lerpTime)
		{
			yield return null;
			curTime += Time.deltaTime;
			if(dir == 1)
			{
				invenPanel.rectTransform.anchoredPosition = Vector2.Lerp(initPos, onPos, curTime / lerpTime);
			}
			else if(dir == -1)
			{
				invenPanel.rectTransform.anchoredPosition = Vector2.Lerp(initPos, offPos, curTime / lerpTime);
			}
			
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeStretch : MonoBehaviour
{
	RectTransform myRect;
	public Vector2 initSize;
	public Vector2 screenSizeWhenInit;



	private void OnGUI()
	{
		myRect = GetComponent<RectTransform>();
		Vector2 size = myRect.sizeDelta;
		size.x = initSize.x * (Screen.width / screenSizeWhenInit.x);
		size.y = initSize.y * (Screen.width / screenSizeWhenInit.y);
		myRect.sizeDelta = size;
	}
}

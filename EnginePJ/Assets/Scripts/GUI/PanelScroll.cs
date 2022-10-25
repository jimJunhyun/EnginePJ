using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelScroll : MonoBehaviour
{
	RectTransform rectT;
	List<Button> childButtons = new List<Button>();
	private void Awake()
	{
		GetComponentsInChildren<Button>(childButtons);
		rectT = GetComponent<RectTransform>();
	}

	private void Update()
	{
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0, childButtons[0].GetComponent<RectTransform>().sizeDelta.y * childButtons.Count));
	}

	public void Scroll(Vector2 pow)
	{
		rectT.Translate(pow);
	}

}

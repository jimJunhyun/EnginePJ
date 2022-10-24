using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollRect : MonoBehaviour, IDragHandler, IBeginDragHandler
{
	public PanelScroll panel;
	public float scrollSpeed;

	Vector3 initMPos;
	int scrollDir;
	public void OnBeginDrag(PointerEventData eventData)
	{
		initMPos = Input.mousePosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if((initMPos - Input.mousePosition).y > 0)
		{
			scrollDir = 1;
		}
		else if ((initMPos - Input.mousePosition).y > 0)
		{
			scrollDir = -1;
		}
		initMPos = Input.mousePosition;
		panel.Scroll(Vector2.up * scrollDir * scrollSpeed * Time.deltaTime);
	}
}

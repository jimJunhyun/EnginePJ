using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public InterPanel selPanel;
	public void OnBeginDrag(PointerEventData eventData)
	{
		if(eventData.hovered.Count >= 3)
		{
			selPanel.gameObject.SetActive(true);
			selPanel.SetFuncs(eventData.hovered.Find((x) => { return x.GetComponent<Interacts>(); }));
			selPanel.transform.position = eventData.position;
		}
		
	}

	public void OnDrag(PointerEventData eventData)
	{

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.hovered.Count >= 3)
		{
			eventData.hovered[eventData.hovered.FindIndex((x) => {return x.GetComponent<DragEndFunc>(); })].GetComponent<DragEndFunc>().OnMouseUp?.Invoke(null);
			selPanel.gameObject.SetActive(false);
		}
	}
}

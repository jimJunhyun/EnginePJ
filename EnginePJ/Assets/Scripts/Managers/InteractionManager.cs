using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
	public InterPanel selPanel;
	public void OnPointerDown(PointerEventData eventData)
	{
		GameObject obj;
		if (obj = eventData.hovered.Find((x) => { return x.GetComponent<Interacts>(); }))
		{
			selPanel.OnPanel();
			selPanel.SetFuncs(obj);
			selPanel.transform.position = eventData.position;
			PlayerCtrl.instance.DeMove();
		}
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		selPanel.OffPanel();
		PlayerCtrl.instance.GoMove();
	}

	public void OnDrag(PointerEventData eventData)
	{

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		GameObject endReel;
		if ((endReel = eventData.hovered.Find((x)=>{return x.GetComponent<DragEndFunc>(); })) != null)
		{
			DragEndFunc endFunc = endReel.GetComponent<DragEndFunc>();
			endFunc.OnMouseUp?.Invoke(PlayerCtrl.instance.ResetInterAnim);
		}
		selPanel.OffPanel();
		PlayerCtrl.instance.GoMove();
	}

	
}

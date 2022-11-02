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
		GameObject obj;
		if(obj = eventData.hovered.Find((x) => { return x.GetComponent<Interacts>(); }))
		{
			selPanel.gameObject.SetActive(true);
			selPanel.SetFuncs(obj);
			selPanel.transform.position = eventData.position;
			PlayerCtrl.instance.DeMove();
		}
		
	}

	public void OnDrag(PointerEventData eventData)
	{

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		GameObject endReel;
		if ((endReel = eventData.hovered.Find((x)=>{return x.GetComponent<DragEndFunc>(); })) != null)
		{
			
			endReel.GetComponent<DragEndFunc>().OnMouseUp?.Invoke(PlayerCtrl.instance.ResetInterAnim);
			
		}
		selPanel.gameObject.SetActive(false);
		PlayerCtrl.instance.GoMove();
	}

}

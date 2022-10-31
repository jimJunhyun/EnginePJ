using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int thisId = -1;
	public UnityEvent<ItemManager.ItemData> OnPressInfo;
	Image myImg;
	ItemManager.ItemData data;
	Vector3 initPos;

	private void Awake()
	{
		myImg = GetComponent<Image>();
		initPos = transform.position;
	}


	public void SetData()
	{
		if(thisId < 0)
		{
			return;
		}
		data = ItemManager.instance.itemIdPairs[thisId];
		myImg.sprite = ItemManager.instance.itemIdPairs[thisId].icon;
	}
	public void PressAct()
	{
		OnPressInfo.Invoke(data);
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = initPos; //?
	}
}

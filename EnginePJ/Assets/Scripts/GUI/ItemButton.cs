using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public int thisId = -1;
	int prevId = 0;
	public UnityEvent<ItemManager.ItemData> OnPressInfo;
	public UnityEvent OnDragInfo;
	public UnityEvent OnWrongInter;
	Image myImg;
	Button myButton;
	RectTransform myRect;
	ItemManager.ItemData data;
	Vector3 initPos;

	private void Awake()
	{
		myImg = GetComponent<Image>();
		myRect = myImg.rectTransform;
		myButton = GetComponent<Button>();
		data = new ItemManager.ItemData(true);
		StartCoroutine(LateSet());
	}

	private void Update()
	{
		if(thisId != prevId)
		{
			SetData();
			prevId = thisId;
		}
	}

	public void SetData()
	{
		if(thisId < 0)
		{
			myImg.enabled = false;
		}
		else
		{
			myImg.enabled = true;
			data = ItemManager.instance.itemIdPairs[thisId];
			myImg.sprite = ItemManager.instance.itemIdPairs[thisId].icon;
		}
		
	}
	public void PressAct()
	{
		if(data.uid > 0)
		{
			OnPressInfo.Invoke(data);
		}
		
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
		myButton.interactable = false;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if(data.progressReq == GameManager.StageProgress.None || data.progressReq == GameManager.instance.curProgress)
		{
			if (data.anyUse)
			{
				data.OnUsed.Invoke();
				myRect.localPosition = initPos;
				myButton.interactable = true;
				Cursor.visible = true;
			}
			else
			{
				ItemInteract endedInter = null;
				RaycastHit2D hit;
				if (hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(eventData.position), 0.1f, Vector2.zero, 0, ItemManager.instance.itemInterLayer))
				{
					endedInter = hit.collider.GetComponent<ItemInteract>();
					if (endedInter.detectingData == data)
					{
						endedInter.OnMatched.Invoke();
						data.OnUsed.Invoke();
					}
				}
				else
				{
					ItemManager.instance.WrongInter();
				}
				myRect.localPosition = initPos;
				myButton.interactable = true;
				Cursor.visible = true;
			}
		}
		else
		{
			ItemManager.instance.WrongInter();
			myRect.localPosition = initPos;
			myButton.interactable = true;
			Cursor.visible = true;
		}
		
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		OnDragInfo.Invoke();
		Cursor.visible = false;
	}

	IEnumerator LateSet()
	{
		yield return null;
		yield return null;
		initPos = myRect.localPosition;
	}

	
}

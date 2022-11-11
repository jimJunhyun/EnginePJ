using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InfoPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOpened;
	public Image informatPanel;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;

	ItemManager.ItemData prevData;
	bool focused = false;

	private void Awake()
	{
		isOpened = false;
		prevData = new ItemManager.ItemData(true);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !focused)
		{
			ForceOffPanel();
		}
	}

	public void ForceOffPanel()
	{
		if (isOpened)
		{
			informatPanel.gameObject.SetActive(false);
			isOpened = false;
			prevData = new ItemManager.ItemData(true);
		}
	}

	public void OnOffPanel(ItemManager.ItemData data)
	{
		if(data.uid < 0)
		{
			throw new System.Exception("존재하지 않는 아이템의 정보 확인 시도 감지됨.");
		}
		if (isOpened)
		{
			if(data.uid == prevData.uid)
			{
				informatPanel.gameObject.SetActive(false);
				isOpened = false;
				prevData = new ItemManager.ItemData(true);
			}
			else
			{
				itemIcon.sprite = data.icon;
				itemName.text = data.name;
				itemDesc.text = data.desc;
				prevData = data;
			}
		}
		else
		{
			informatPanel.gameObject.SetActive(true);
			itemIcon.sprite = data.icon;
			itemName.text = data.name;
			itemDesc.text = data.desc;
			prevData = data;
			isOpened = true;
		}
		
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		focused = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		focused = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public bool isOpened;
	public Image informatPanel;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;

	ItemManager.ItemData prevData;

	private void Awake()
	{
		isOpened = false;
		prevData = new ItemManager.ItemData(){uid = -1 };
	}

	public void OnOffPanel(ItemManager.ItemData data)
	{
		if (isOpened)
		{
			if(data.uid == prevData.uid)
			{
				informatPanel.gameObject.SetActive(false);
				isOpened = false;
				prevData = new ItemManager.ItemData();
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

}

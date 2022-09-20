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

	private void Awake()
	{
		isOpened = false;

	}

	public void OnOffPanel(ItemManager.ItemData data)
	{
		if (isOpened)
		{
			informatPanel.gameObject.SetActive(false);
			isOpened = false;
		}
		else
		{
			informatPanel.gameObject.SetActive(true);
			itemIcon.sprite = data.icon;
			itemName.text = data.name;
			itemDesc.text = data.desc;
			isOpened = true;
		}
		
	}

}

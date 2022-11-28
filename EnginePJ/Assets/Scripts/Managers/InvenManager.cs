using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : MonoBehaviour
{
	const int INVENTORY_SIZE = 10;

	public InfoPanel panel;
	List<ItemManager.ItemData> items = new List<ItemManager.ItemData>(new ItemManager.ItemData[10]);
	List<ItemButton> slots = new List<ItemButton>(); 
	int idx = 0;

	private void Awake()
	{
		GetComponentsInChildren(slots);
	}
	IEnumerator PanelAfterClick()
	{
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		yield return new WaitForSeconds(0.25f);
		panel.ForceOffPanel();
		panel.OnOffPanel(items[idx]);
	}
	public void ItemGet(int itemId)
	{
		items[idx] = ItemManager.instance.itemIdPairs[itemId];
		slots[idx].thisId = ItemManager.instance.itemIdPairs[itemId].uid;
		if (panel.isOpened)
		{
			StartCoroutine(PanelAfterClick());
		}
		else
		{
			panel.OnOffPanel(items[idx]);
			++idx;
		}
	}
	public void ItemUse(int itemId)
	{
		ItemManager.ItemData foundItem;
		int foundIdx;
		if ((foundItem = items.Find((x)=>{ return itemId == x.uid;})) != null)
		{
			foundIdx = items.FindIndex((x) => { return foundItem == x; });
			items[foundIdx] = new ItemManager.ItemData(true);
			slots[foundIdx].thisId = -1;
			if (foundIdx != 9)
			{
				for (int i = foundIdx; i < INVENTORY_SIZE; i++)
				{
					if(i < INVENTORY_SIZE - 1 && slots[i + 1].thisId >-1)
					{
						slots[i].thisId = slots[i + 1].thisId;
						items[i] = items[i + 1];
					}
					else
					{
						slots[i].thisId = -1;
						items[i] = new ItemManager.ItemData(true);
						idx = i;
						break;
					}
				}
				
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : MonoBehaviour
{
	const int INVENTORY_SIZE = 10;

	List<ItemManager.ItemData> items = new List<ItemManager.ItemData>(new ItemManager.ItemData[10]);
	List<ItemButton> slots = new List<ItemButton>(); 
	int idx = 0;

	private void Awake()
	{
		GetComponentsInChildren(slots);
	}

	public void ItemGet(int dataIdx)
	{
		items[idx] = ItemManager.instance.itemIdPairs[dataIdx];
		slots[idx].thisId = ItemManager.instance.itemIdPairs[dataIdx].uid;
		slots[idx].SetData();
		++idx;
	}
	public void ItemUse(int dataIdx)
	{
		//?
		items[idx] = new ItemManager.ItemData(true);
		slots[idx].thisId = -1; 
	}
}

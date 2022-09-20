using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public int thisId;
	ItemManager.ItemData data;
	private void Awake()
	{
		
	}
	public void PressAct()
	{
		data = ItemManager.instance.itemIdPairs[thisId];
	}
}

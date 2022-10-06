using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour
{
    public int thisId;
	public UnityEvent<ItemManager.ItemData> OnPressInfo;
	ItemManager.ItemData data;
	private void Start()
	{
		data = ItemManager.instance.itemIdPairs[thisId];
	}
	public void PressAct()
	{
		OnPressInfo.Invoke(data);
	}
}

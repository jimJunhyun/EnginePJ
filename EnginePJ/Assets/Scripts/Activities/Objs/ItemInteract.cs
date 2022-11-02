using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteract : MonoBehaviour
{
    public UnityEvent OnMatched;
    public int detecingItem;
    public ItemManager.ItemData detectingData;

	private void Start()
	{
		detectingData = ItemManager.instance.itemIdPairs[detecingItem];
	}
	public void TempF()
	{
		Debug.Log("(!)(?)");
	}
}

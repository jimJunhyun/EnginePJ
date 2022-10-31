using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance;

	public List<Sprite> icons = new List<Sprite>();

	public enum ItemIds
	{
		None = -1,
		Phone,
		Box,
		LMAO,

	}

	public struct ItemData
	{
		public int uid { get; set;}
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>();


	private void Awake()
	{
		instance = this;
		itemIdPairs = new Dictionary<int, ItemData>()
		{
			{((int)ItemIds.Phone), new ItemData(){uid = (int)ItemIds.Phone, name = "스마트폰", desc = "스마트폰이다. 약간 구형 기종이다.", icon = icons[0]} },
			{((int)ItemIds.Box), new ItemData(){uid = (int)ItemIds.Box,name = "상자", desc = "골판지 상자다. 덜컹거리는 것이 안에 무언가 든 것 같다.", icon = icons[1]} },
			{((int)ItemIds.LMAO), new ItemData(){uid = (int)ItemIds.LMAO,name = "하하", desc = "껄껄껄", icon = icons[2]} },
		};
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
	}
}

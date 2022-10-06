using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 획득과 최대 갯수 등을 관리함.
/// 개별 아이템의 경우 아이템 데이터로 관리.
/// 인벤토리의 사용을 수반함.
/// </summary>
public class ItemManager : MonoBehaviour
{
	public static ItemManager instance;

	public List<Sprite> icons = new List<Sprite>();
	public List<ItemData> ItemList = new List<ItemData>();

	enum ItemIds
	{
		None = -1,
		Key,

	}

	public struct ItemData
	{
		public int uid { get; set;}
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>();

	

	public void ObtainItem(int id)
	{
		ItemList.Add(itemIdPairs[id]);
	}

	private void Awake()
	{
		instance = this;
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
		itemIdPairs = new Dictionary<int, ItemData>()
		{
			{0, new ItemData(){uid = 0, name = "Key", desc = "It's a small golden key. Looks a little damaged.", icon = icons[0]} },
			{1, new ItemData(){uid = 1,name = "이름2", desc = "Test2", icon = icons[1]} },
			{2, new ItemData(){uid = 2,name = "이름3", desc = "Test3", icon = icons[2]} },
		};
		Debug.Log(itemIdPairs.Count);
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
	}
}

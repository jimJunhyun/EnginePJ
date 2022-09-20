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

	enum ItemIds
	{
		None = -1,
		Key,

	}

	public struct ItemData
	{
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>()
	{
		{0, new ItemData(){name = "열쇠", desc = "작은 열쇠다. 조금 닳아있다."} },
		{1, new ItemData(){name = "이름2", desc = "Test2"} },
		{2, new ItemData(){name = "이름3", desc = "Test3"} },
	};

	public List<ItemData> ItemList = new List<ItemData>();

	public void GetItem(int id)
	{
		ItemList.Add(itemIdPairs[id]);
	}
}

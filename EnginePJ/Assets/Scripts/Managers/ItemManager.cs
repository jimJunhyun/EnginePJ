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

	public struct ItemData
	{
		public string name { get; set;}
		public string desc { get; set;}
		public int num { get; set;}
		public Sprite icon { get; set;}
		public delegate void Useeff();
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>()
	{
		{1, new ItemData(){name = "이름", desc = "Test", num = 1} },
		{2, new ItemData(){name = "이름2", desc = "Test2", num = 1} },
		{3, new ItemData(){name = "이름3", desc = "Test3", num = 1} },
	};

	public List<ItemData> allItem = new List<ItemData>();
	public List<ItemData> inventory = new List<ItemData>();
	private void Awake()
	{
		foreach (var item in itemIdPairs.Values)
		{
			allItem.Add(item);
		}
	}
	public void GetItem(int id)
	{
		inventory.Add(itemIdPairs[id]);
	}
	public void UseItem(int id)
	{

	}
}

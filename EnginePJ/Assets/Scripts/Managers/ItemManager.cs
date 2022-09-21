using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ȹ��� �ִ� ���� ���� ������.
/// ���� �������� ��� ������ �����ͷ� ����.
/// �κ��丮�� ����� ������.
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
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>();

	

	public void GetItem(int id)
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
			{0, new ItemData(){name = "Key", desc = "It's a small golden key. Looks a little damaged.", icon = icons[0]} },
			{1, new ItemData(){name = "�̸�2", desc = "Test2", icon = icons[1]} },
			{2, new ItemData(){name = "�̸�3", desc = "Test3", icon = icons[2]} },
		};
		Debug.Log(itemIdPairs.Count);
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
	}
}

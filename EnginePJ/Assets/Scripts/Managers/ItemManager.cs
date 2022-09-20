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
		{0, new ItemData(){name = "����", desc = "���� �����. ���� ����ִ�."} },
		{1, new ItemData(){name = "�̸�2", desc = "Test2"} },
		{2, new ItemData(){name = "�̸�3", desc = "Test3"} },
	};

	public List<ItemData> ItemList = new List<ItemData>();

	public void GetItem(int id)
	{
		ItemList.Add(itemIdPairs[id]);
	}
}

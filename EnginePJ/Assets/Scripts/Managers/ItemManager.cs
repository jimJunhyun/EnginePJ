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
		{1, new ItemData(){name = "�̸�", desc = "Test", num = 1} },
		{2, new ItemData(){name = "�̸�2", desc = "Test2", num = 1} },
		{3, new ItemData(){name = "�̸�3", desc = "Test3", num = 1} },
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

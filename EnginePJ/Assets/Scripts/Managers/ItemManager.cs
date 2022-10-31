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
			{((int)ItemIds.Phone), new ItemData(){uid = (int)ItemIds.Phone, name = "����Ʈ��", desc = "����Ʈ���̴�. �ణ ���� �����̴�.", icon = icons[0]} },
			{((int)ItemIds.Box), new ItemData(){uid = (int)ItemIds.Box,name = "����", desc = "������ ���ڴ�. ���ȰŸ��� ���� �ȿ� ���� �� �� ����.", icon = icons[1]} },
			{((int)ItemIds.LMAO), new ItemData(){uid = (int)ItemIds.LMAO,name = "����", desc = "������", icon = icons[2]} },
		};
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
	}
}

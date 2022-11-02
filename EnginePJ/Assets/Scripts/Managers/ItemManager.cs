using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance;

	public int itemInterLayer = 10;
	public List<Sprite> icons = new List<Sprite>();

	public enum ItemIds
	{
		None = -1,
		Box,
		LMAO,

	}

	public struct ItemData
	{
		public int uid { get; set;}
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
		public bool dispensable { get; set;}
		public bool anyUse { get; set;}

		public ItemData(bool isDummy)
		{
			uid = -1;
			name = "������������.";
			desc = "������������.";
			icon = null;
			dispensable = true;
			anyUse = false;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public static bool operator== (ItemData a, ItemData b)
		{
			return a.uid == b.uid;
		}
		public static bool operator!= (ItemData a, ItemData b)
		{
			return a.uid != b.uid;
		}
	}
	public Dictionary<int, ItemData> itemIdPairs = new Dictionary<int, ItemData>();


	private void Awake()
	{
		instance = this;
		itemInterLayer = 1 << itemInterLayer;
		itemIdPairs = new Dictionary<int, ItemData>()
		{
			{((int)ItemIds.Box), new ItemData(){uid = (int)ItemIds.Box,name = "����", desc = "������ ���ڴ�. ���ȰŸ��� ���� �ȿ� ���� �� �� ����.", icon = icons[1], dispensable = true, anyUse = true} },
			{((int)ItemIds.LMAO), new ItemData(){uid = (int)ItemIds.LMAO,name = "����", desc = "������", icon = icons[2], dispensable = true, anyUse = false} },
		};
		foreach (var item in itemIdPairs.Keys)
		{
			Debug.Log(item + " : " + itemIdPairs[item]);
		}
	}
}

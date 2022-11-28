using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance;

	public int itemInterLayer = 10;
	public List<Sprite> icons = new List<Sprite>();
	public List<UnityEvent> events = new List<UnityEvent>();

	public enum ItemIds
	{
		None = -1,
		Box,
		VideoTape,
		Lighter,
		Doll,
		Note,

	}

	public struct ItemData
	{
		public int uid { get; set;}
		public string name { get; set;}
		public string desc { get; set;}
		public Sprite icon { get; set;}
		public bool anyUse { get; set;}
		public float useTime { get;set;}
		public GameManager.StageProgress progressReq { get; set;}
		public UnityEvent OnUsed { get; set;}

		public ItemData(bool isDummy)
		{
			uid = -1;
			name = "������������.";
			desc = "������������.";
			icon = null;
			anyUse = false;
			useTime = 0;
			progressReq = GameManager.StageProgress.None;
			OnUsed = null;
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


	const string WRONGINTER_WORDS = "�׷��Դ� �� �� ����.";

	private void Awake()
	{
		instance = this;
		itemInterLayer = 1 << itemInterLayer;
		itemIdPairs = new Dictionary<int, ItemData>()
		{
			{((int)ItemIds.Box), new ItemData(){uid = (int)ItemIds.Box,name = "����", desc = "����ϰ� ���� ���� ������ ������ ��� �ڽ��̴�.", icon = icons[(int)ItemIds.Box], anyUse = true, useTime = 1f, progressReq = GameManager.StageProgress.Home, OnUsed = events[(int)ItemIds.Box]} },
			{((int)ItemIds.VideoTape), new ItemData(){uid = (int)ItemIds.VideoTape,name = "ī��Ʈ������", desc = "���� ��� ����� ����ִ� ����� �����̴�.", icon = icons[(int)ItemIds.VideoTape], anyUse = false, useTime = 1f, progressReq = GameManager.StageProgress.Home, OnUsed = events[(int)ItemIds.VideoTape]} },
			{((int)ItemIds.Lighter), new ItemData(){uid = (int)ItemIds.Lighter,name = "������", desc = "���� �����ʹ�. ȣ���� �׸��� �λ����̴�.", icon = icons[(int)ItemIds.Lighter], anyUse = true, useTime = 0.5f, progressReq = GameManager.StageProgress.None, OnUsed = events[(int)ItemIds.Lighter]} },
			{((int)ItemIds.Doll), new ItemData(){uid = (int)ItemIds.Doll,name = "����", desc = "������ �����̴�. �������� �߾��� ����ִ�.", icon = icons[(int)ItemIds.Doll], anyUse = false, useTime = 0.5f, progressReq = GameManager.StageProgress.Alley, OnUsed = events[(int)ItemIds.Doll]} },
			{((int)ItemIds.Note), new ItemData(){uid = (int)ItemIds.Note,name = "��å", desc = "����б� ���� ���� ��Ʈ�������̴�.", icon = icons[(int)ItemIds.Note], anyUse = false, useTime = 0.5f, progressReq = GameManager.StageProgress.None, OnUsed = events[(int)ItemIds.Note]} },
		};
	}

	public void WrongInter()
	{
		PlayerCtrl.instance.GetComponent<PlayerSpeak>().Show(WRONGINTER_WORDS);
	}
}

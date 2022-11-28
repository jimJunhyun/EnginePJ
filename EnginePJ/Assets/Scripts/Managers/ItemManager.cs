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
			name = "존재하지않음.";
			desc = "존재하지않음.";
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


	const string WRONGINTER_WORDS = "그렇게는 할 수 없다.";

	private void Awake()
	{
		instance = this;
		itemInterLayer = 1 << itemInterLayer;
		itemIdPairs = new Dictionary<int, ItemData>()
		{
			{((int)ItemIds.Box), new ItemData(){uid = (int)ItemIds.Box,name = "상자", desc = "골판지 상자다. 덜컹거리는 것이 안에 무언가 든 것 같다.", icon = icons[(int)ItemIds.Box], anyUse = true, useTime = 1f, progressReq = GameManager.StageProgress.Home, OnUsed = events[(int)ItemIds.Box]} },
			{((int)ItemIds.VideoTape), new ItemData(){uid = (int)ItemIds.VideoTape,name = "카세트테이프", desc = "오래된 카세트 테이프다. 왠지 익숙한 기분이다.", icon = icons[(int)ItemIds.VideoTape], anyUse = false, useTime = 1f, progressReq = GameManager.StageProgress.Home, OnUsed = events[(int)ItemIds.VideoTape]} },
			{((int)ItemIds.Lighter), new ItemData(){uid = (int)ItemIds.Lighter,name = "라이터", desc = "낡은 라이터다. 호랑이 그림이 인상적이다.", icon = icons[(int)ItemIds.Lighter], anyUse = true, useTime = 0.5f, progressReq = GameManager.StageProgress.None, OnUsed = events[(int)ItemIds.Lighter]} },
			{((int)ItemIds.Doll), new ItemData(){uid = (int)ItemIds.Doll,name = "인형", desc = "오래된 인형이다. 누군가의 추억이 담겨있다.", icon = icons[(int)ItemIds.Doll], anyUse = false, useTime = 0.5f, progressReq = GameManager.StageProgress.Alley, OnUsed = events[(int)ItemIds.Doll]} },
		};
	}

	public void WrongInter()
	{
		PlayerCtrl.instance.GetComponent<PlayerSpeak>().Show(WRONGINTER_WORDS);
	}
}

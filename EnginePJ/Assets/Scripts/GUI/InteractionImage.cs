using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionImage : MonoBehaviour
{
    const string PATH = "InteractionPanel/";
	public Image myImg;
    Dictionary<Interacts.AllInteractions, string> actPathNamePair = new Dictionary<Interacts.AllInteractions, string>
	{
		{ Interacts.AllInteractions.Look, "Eye" },
		{ Interacts.AllInteractions.Obtain, "Hand" },
	};

	private void Awake()
	{
		myImg = GetComponent<Image>();
	}

	public void SetImage(Interacts.AllInteractions inter)
	{
		if (actPathNamePair.ContainsKey(inter))
		{
			myImg.sprite = Resources.Load<Sprite>(PATH + actPathNamePair[inter]);
		}
	}
}

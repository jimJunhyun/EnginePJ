using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switches : MonoBehaviour
{
	public int curSymbol;
	Text temp;
	private void Awake()
	{
		curSymbol = ((int)BoxRule.Symbols.Circle);
		temp = GetComponentInChildren<Text>();
		temp.text = Enum.GetName(typeof(BoxRule.Symbols), curSymbol);
	}
	public void ChangeSymbol()
	{
		++curSymbol;
		if(curSymbol >= ((int)BoxRule.Symbols.Max))
		{
			curSymbol = ((int)BoxRule.Symbols.Circle);
		}
		//여기 애니메이션 적용시키기 (버튼 애니메이션 스왑 기능 이용)
		temp.text = Enum.GetName(typeof(BoxRule.Symbols), curSymbol);
	}
}

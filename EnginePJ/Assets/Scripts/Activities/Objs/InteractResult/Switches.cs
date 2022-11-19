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
		//���� �ִϸ��̼� �����Ű�� (��ư �ִϸ��̼� ���� ��� �̿�)
		temp.text = Enum.GetName(typeof(BoxRule.Symbols), curSymbol);
	}
}

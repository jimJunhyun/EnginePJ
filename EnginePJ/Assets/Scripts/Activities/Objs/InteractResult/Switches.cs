using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switches : MonoBehaviour
{
	public int curSymbol;
	public float singleSymOff;
	Text temp;
	Image img;
	Material mat;
	private void Awake()
	{
		curSymbol = ((int)BoxRule.Symbols.Butterfly);
		img = GetComponent<Image>();
		temp = GetComponentInChildren<Text>();
		temp.text = Enum.GetName(typeof(BoxRule.Symbols), curSymbol);
		mat = img.material;
		mat.SetFloat("Vector1_Offset" , 0.12f);
	}
	public void ChangeSymbol()
	{
		++curSymbol;
		if(curSymbol >= ((int)BoxRule.Symbols.Max))
		{
			curSymbol = ((int)BoxRule.Symbols.Butterfly);
		}
		//여기 애니메이션 적용시키기 (버튼 애니메이션 스왑 기능 이용)
		float a = mat.GetFloat("Vector1_Offset");
		mat.SetFloat("Vector1_Offset", a + singleSymOff);
		if (mat.GetFloat("Vector1_Offset") < -0.78f)
		{
			mat.SetFloat("Vector1_Offset", 0.12f);
		}
		
		temp.text = Enum.GetName(typeof(BoxRule.Symbols), curSymbol);
	}
}

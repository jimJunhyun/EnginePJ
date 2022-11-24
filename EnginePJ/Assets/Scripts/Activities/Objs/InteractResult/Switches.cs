using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switches : MonoBehaviour
{
	public int curSymbol;
	Image img;
	Material mat;
	BoxRule rule;
	bool rolling = false;
	private void Awake()
	{
		curSymbol = ((int)BoxRule.Symbols.Butterfly);
		img = GetComponent<Image>();
		rule = GetComponentInParent<BoxRule>();
		mat = img.material;
		mat.SetFloat("Vector1_Offset" , 0.12f);
	}
	public void ChangeSymbol()
	{
		if (!rolling)
		{
			StartCoroutine(LerpFloat());
			
		}
		
	}

	IEnumerator LerpFloat()
	{
		rolling = true;
		float t = 0;
		float curOffset = mat.GetFloat("Vector1_Offset");
		float butterflyOffset = 0;
		while (t < rule.LerpMoveTime)
		{
			yield return null;
			t += Time.deltaTime;
			if(curSymbol == ((int)BoxRule.Symbols.Fish))
			{
				mat.SetFloat("Vector1_Offset", Mathf.Lerp(curOffset, -0.72f, t / rule.LerpMoveTime));
			}
			else
			{
				mat.SetFloat("Vector1_Offset", Mathf.Lerp(curOffset, curOffset + rule.singleSymbolOffset + butterflyOffset, t / rule.LerpMoveTime));
			}
			
		}
		if(curSymbol == ((int)BoxRule.Symbols.Fish))
		{
			mat.SetFloat("Vector1_Offset", 0.12f);
		}
		++curSymbol;
		if (curSymbol >= ((int)BoxRule.Symbols.Max))
		{
			curSymbol = ((int)BoxRule.Symbols.Butterfly);
		}
		rolling = false;
	}
}

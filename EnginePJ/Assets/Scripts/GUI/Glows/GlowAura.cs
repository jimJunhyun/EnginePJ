using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAura : MonoBehaviour
{
    public float lerpSpeed;
	public float alphaMax;

	SpriteRenderer sprend;
	Color currentCol;
	// Update is called once per frame
	private void Awake()
	{
		sprend = GetComponent<SpriteRenderer>();
		currentCol = sprend.color;
		currentCol.a = 0;
		sprend.color = currentCol;
	}

	private void Update()
	{
		
	}

	IEnumerator LerpAlpha()
	{
		while(currentCol.a != alphaMax)
		{
			yield return null;
			currentCol = sprend.color;
			if(currentCol.a < alphaMax)
			{
				currentCol.a = Mathf.Lerp(currentCol.a, alphaMax, (currentCol.a / alphaMax) * lerpSpeed) ;
			}

			sprend.color = currentCol;
		}
	}
}

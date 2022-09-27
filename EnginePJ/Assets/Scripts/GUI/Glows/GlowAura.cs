using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAura : MonoBehaviour
{
    public float lerpTime;
	[Range(0,1)]
	public float alphaMax;

	SpriteRenderer sprend;
	Color currentCol;
	Coroutine starter;
	Coroutine ender;
	// Update is called once per frame
	private void Awake()
	{
		sprend = GetComponent<SpriteRenderer>();
		currentCol = sprend.color;
		currentCol.a = 0;
		sprend.color = currentCol;
	}

	public void OnLight()
	{
		if (ender != null)
		{
			StopCoroutine(ender);
			ender = null;
		}
		if (starter == null)
		{
			starter = StartCoroutine(LerpAlpha(alphaMax));
		}
		
	}

	public void OffLight()
	{
		if (starter != null)
		{
			StopCoroutine(starter);
			starter = null;
		}
		if (ender == null)
		{
			ender = StartCoroutine(LerpAlpha(0));
		}
		
	}

	IEnumerator LerpAlpha(float alpha)
	{
		float timepass = 0f;
		Color initCol = sprend.color;
		while(timepass <= lerpTime)
		{
			timepass += Time.deltaTime;
			yield return null;
			currentCol = sprend.color;
			currentCol.a = Mathf.Lerp(initCol.a, alpha, timepass / lerpTime) ;
			sprend.color = currentCol;
		}
	}
}

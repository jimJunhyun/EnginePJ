using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFade : MonoBehaviour
{
	public float fadeMax;
	public float fadeTime;

	Material fadeMat;
	Image img;
	private void Awake()
	{
		img = GetComponent<Image>();
		fadeMat = img.material;
		fadeMat.SetFloat("CircleSize", 0);
		fadeMat.SetInt("EntireBlack", 0);
	}
	public void Fade()
	{
		StartCoroutine(LerpFade());
	}
	public void DelayFade(float d)
	{
		StartCoroutine(LerpFade(d));
	}
	public void FadeAppear()
	{
		StartCoroutine(LerpFadeAppear());
	}
	public void DelayFadeAppear(float d)
	{
		StartCoroutine(LerpFadeAppear(d));
	}
	IEnumerator LerpFade(float delay = 0f)
	{
		yield return new WaitForSeconds(delay);
		float t = 0;
		while(t < fadeTime)
		{
			yield return null;
			t += Time.deltaTime;
			fadeMat.SetFloat("CircleSize", Mathf.Lerp(0, fadeMax, t / fadeTime));
		}
		fadeMat.SetInt("EntireBlack", 1);
	}
	IEnumerator LerpFadeAppear(float delay = 0f)
	{
		yield return new WaitForSeconds(delay);
		fadeMat.SetInt("EntireBlack", 0);
		float t = 0;
		while (t < fadeTime)
		{
			yield return null;
			t += Time.deltaTime;
			fadeMat.SetFloat("CircleSize", Mathf.Lerp(fadeMax, 0, t / fadeTime));
		}
		
	}
}

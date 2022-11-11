using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFade : MonoBehaviour
{
	public float fadeMax;
	public float fadeTime;

	public float preDel;
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
	IEnumerator LerpFade()
	{
		yield return new WaitForSeconds(preDel);
		float t = 0;
		while(t < fadeTime)
		{
			yield return null;
			t += Time.deltaTime;
			fadeMat.SetFloat("CircleSize", Mathf.Lerp(0, fadeMax, t / fadeTime));
		}
		fadeMat.SetInt("EntireBlack", 1);
	}
}

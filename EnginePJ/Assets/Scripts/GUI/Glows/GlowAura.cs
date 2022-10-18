using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAura : MonoBehaviour
{
    public float lerpTime;
	[Range(0,0.08f)]
	public float glowMax;

	SpriteRenderer sprend;
	Material glowMat;
	Coroutine starter;
	Coroutine ender;
	// Update is called once per frame
	private void Awake()
	{
		sprend = GetComponent<SpriteRenderer>();
		glowMat = sprend.material;
		glowMat.SetFloat("GlowDep", 0f);
		glowMat.SetInt("GlowDis", 1);
	}

	private void Update()
	{
		if (glowMat.GetFloat("GlowDep") == 0)
		{
			glowMat.SetInt("GlowDis", 1);
		}
		else
		{
			glowMat.SetInt("GlowDis", 0);
		}
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
			starter = StartCoroutine(LerpDepth(glowMax));
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
			ender = StartCoroutine(LerpDepth(0));
		}
		
	}

	IEnumerator LerpDepth(float dep)
	{
		float timepass = 0f;
		float initDep = glowMat.GetFloat("GlowDep");
		while (timepass <= lerpTime)
		{
			timepass += Time.deltaTime;
			yield return null;
			glowMat.SetFloat("GlowDep", Mathf.Lerp(initDep, dep, timepass / lerpTime)) ;
		}
	}
}

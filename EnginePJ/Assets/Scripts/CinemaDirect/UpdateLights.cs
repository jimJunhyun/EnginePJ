using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 매니저에 붙어있음.
/// </summary>
public class UpdateLights : MonoBehaviour
{
	public bool isComp;
    public Light2D source;
	
	float transTime;

	public void EmptyFunc()
	{
		isComp = true;
	}

	public void AdjustLight(float value)
	{
		source.intensity = value;
		isComp = true;
	}

	public void AdjustSmooth(float val)
	{
		StartCoroutine(DelayAdjust(val));
	}

	public void SetTrans(float val)
	{
		transTime = val;
		isComp = true;
	}

	IEnumerator DelayAdjust(float value)
	{
		float timePassed = 0;
		float initIts = source.intensity;
		while(timePassed <= transTime)
		{
			yield return null;
			timePassed += Time.deltaTime;
			source.intensity = Mathf.Lerp(initIts, value, timePassed / transTime);
		}

		isComp = true;
	}
}

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

	public void AdjustLight(float value)
	{
		source.intensity = value;
		isComp = true;
	}

	public void AdjustSmooth(Vector2 valAndTime)
	{
		StartCoroutine(DelayAdjust(valAndTime.x, valAndTime.y));
	}

	IEnumerator DelayAdjust(float value, float time)
	{
		float timePassed = 0;
		while(timePassed <= time)
		{
			yield return null;
			timePassed += Time.deltaTime;
			source.intensity = Mathf.Lerp(source.intensity, value, timePassed / time);
		}

		isComp = true;
	}
}

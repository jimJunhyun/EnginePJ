using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class UpdateLights : MonoBehaviour
{
    public Light2D source;

    public void AdjustLight(float value, bool smooth = true, float trTime = 1)
	{
		if (smooth)
		{
			StartCoroutine(DelayAdjust(value, trTime));
		}
		else
		{
			source.intensity = value;
		}
		
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
	}
}

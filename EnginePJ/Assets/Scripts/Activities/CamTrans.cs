using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTrans : MonoBehaviour
{
    public const int USING = 15;
    public const int NOTUSING = 10;
    public CinemachineVirtualCamera currentCam;

    CinemachineBrain myBrain;
    float delay = 0;

	private void Awake()
	{
		myBrain = GetComponent<CinemachineBrain>();
	}
    public void SetDel(float t)
	{
        delay = t;
	}
	public void ChangeCam(CinemachineVirtualCamera cam)
	{
        StartCoroutine(DelayChange(cam, delay, false));
	}
    public void InstantChangeCam(CinemachineVirtualCamera cam)
	{
        
        StartCoroutine(DelayChange(cam, delay, true));
        
    }
    IEnumerator DelayChange(CinemachineVirtualCamera cam, float t, bool isInstant)
	{
        yield return new WaitForSeconds(t);
		if (isInstant)
		{
            myBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
		}
		else
		{
            myBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
            myBrain.m_DefaultBlend.m_Time = 1.5f;
		}
        
        currentCam.Priority = NOTUSING;
        cam.Priority = USING;
    }
}

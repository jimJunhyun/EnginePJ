using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTrans : MonoBehaviour
{
    const int USING = 15;
    const int NOTUSING = 10;
    public CinemachineVirtualCamera currentCam;

    CinemachineBrain myBrain;

	private void Awake()
	{
		myBrain = GetComponent<CinemachineBrain>();
	}

	public void ChangeCam(CinemachineVirtualCamera cam)
	{
        myBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        myBrain.m_DefaultBlend.m_Time = 1.5f;
        currentCam.Priority = NOTUSING;
        cam.Priority = USING;
	}
    public void InstantChangeCan(CinemachineVirtualCamera cam)
	{
        myBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        currentCam.Priority = NOTUSING;
        cam.Priority = USING;
        transform.position = cam.transform.position;
    }
}

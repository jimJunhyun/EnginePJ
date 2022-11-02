using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTrans : MonoBehaviour
{
    const int USING = 15;
    const int NOTUSING = 10;
    public CinemachineVirtualCamera currentCam;

    public void ChangeCam(CinemachineVirtualCamera cam)
	{
        currentCam.Priority = NOTUSING;
        cam.Priority = USING;
	}
}

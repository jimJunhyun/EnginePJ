using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTransition : MonoBehaviour
{
    public bool isComp;
    const int NOTUSING = 10;
    const int USING = 20;

    public List<CinemachineVirtualCamera> camPoses;

    float delayTime;
    int idx = 0;
    public void EmptyFunc()
    {
        isComp = true;
    }
    public void DelEmpFunc(float t)
    {
        StartCoroutine(DelayEmpty(t));
    }
    private void Awake()
	{
		for (int i = 0; i < camPoses.Count; i++)
		{
            camPoses[i].Priority = NOTUSING;
		}
        camPoses[0].Priority = USING;
        SetDel(1);
	}

    public void NextCamPos()
	{
        camPoses[idx].Priority = NOTUSING;
        ++idx;
        camPoses[idx].Priority = USING;
        StartCoroutine(CheckArrival());
    }

    public void SetDel(float val)
	{
        delayTime = val;
	}
    IEnumerator DelayEmpty(float t)
    {
        yield return new WaitForSeconds(t);
        isComp = true;
    }
    IEnumerator CheckArrival()
	{
        while(camPoses[idx].transform.position != Camera.main.transform.position)
		{
            yield return null;
		}
        yield return new WaitForSeconds(delayTime);
        isComp = true;
	}
}

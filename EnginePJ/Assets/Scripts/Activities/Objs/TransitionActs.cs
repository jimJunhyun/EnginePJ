using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class TransitionActs : MonoBehaviour
{
    public UnityEvent OnTransite;
	CinemachineVirtualCamera myCam;
	bool changed = false;
	private void Awake()
	{
		myCam = GetComponent<CinemachineVirtualCamera>();
	}
	private void Update()
	{
		if(myCam.m_Priority == CamTrans.USING && !changed)
		{
			changed = true;
			OnTransite.Invoke();
		}
		if(myCam.m_Priority == CamTrans.NOTUSING)
		{
			changed = false;
		}
	}
}

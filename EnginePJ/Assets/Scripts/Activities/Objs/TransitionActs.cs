using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class TransitionActs : MonoBehaviour
{
    public UnityEvent OnTransite;
	public bool isOnce = true;
	CinemachineVirtualCamera myCam;
	bool changed = false;
	bool able = true;
	private void Awake()
	{
		myCam = GetComponent<CinemachineVirtualCamera>();
	}
	private void Update()
	{
		if(myCam.m_Priority == CamTrans.USING && !changed && able)
		{
			changed = true;
			OnTransite.Invoke();
			if (isOnce)
			{
				able = false;
				Debug.Log("변경된 후 비활성");
			}
		}
		if(myCam.m_Priority == CamTrans.NOTUSING)
		{
			changed = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacts : MonoBehaviour
{
    public UnityEvent OnInter;
    public bool isInterable;

    public void Act()
	{
		if (isInterable)
		{
			OnInter?.Invoke();
		}
	}

	public void Deactivate()
	{
		isInterable = false;
	}
	public void Activate()
	{
		isInterable = true;
	}
}

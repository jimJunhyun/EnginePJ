using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacts : MonoBehaviour
{
    public UnityEvent OnInter;
    public bool isInterable;
	public float interactTime;

    public void Act()
	{
		if (isInterable)
		{
			OnInter?.Invoke();
			StartCoroutine(WaitInteract());
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
	IEnumerator WaitInteract()
	{
		Debug.Log("inter start");
		Deactivate();
		PlayerCtrl.instance.DeMove();
		yield return new WaitForSeconds(interactTime);
		Debug.Log("inter end");
		Activate();
		PlayerCtrl.instance.GoMove();
	}
}

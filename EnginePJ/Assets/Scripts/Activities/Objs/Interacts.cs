using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlowAura))]
public class Interacts : MonoBehaviour
{
    public UnityEvent OnInter;
    public bool isInterable;
	public float interactTime;

	public void Act(System.Action onComp = null)
	{
		if (isInterable)
		{
			OnInter?.Invoke();
			StartCoroutine(WaitInteract(onComp));
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
	IEnumerator WaitInteract(System.Action onComp = null)
	{
		Deactivate();
		PlayerCtrl.instance.DeMove();
		yield return new WaitForSeconds(interactTime);
		Debug.Log("!");
		Activate();
		PlayerCtrl.instance.GoMove();
		onComp?.Invoke();
		Debug.Log("E");
	}
}

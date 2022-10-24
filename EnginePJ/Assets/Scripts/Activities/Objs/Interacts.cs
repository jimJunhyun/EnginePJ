using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GlowAura))]
public class Interacts : MonoBehaviour
{
	public enum AllInteractions
	{
		None = -1,

		Look,
		Obtain,


		Max
	}

	public UnityEvent OnLook;
    public UnityEvent OnObt;
    public bool isInterable;
	public float interactTime;
	public List<AllInteractions> ableInters;

	[HideInInspector]
	public List<UnityAction<System.Action>> allActions = new List<UnityAction<System.Action>>();

	Dictionary<AllInteractions, UnityAction<System.Action>> actions;

	private void Awake()
	{
		actions = new Dictionary<AllInteractions, UnityAction<System.Action>>{
			{ AllInteractions.Look,  Look},
			{ AllInteractions.Obtain, Obtain },

		};
		for (int i = 0; i < ableInters.Count; i++)
		{
			allActions.Add(actions[ableInters[i]]);
		}
	}

	public void Look(System.Action onComp = null)
	{
		if(isInterable && ableInters.Contains(AllInteractions.Look))
		{
			OnLook?.Invoke();
			StartCoroutine(WaitInteract(onComp));
		}
	}

	public void Obtain(System.Action onComp = null)
	{
		if (isInterable && ableInters.Contains(AllInteractions.Obtain))
		{
			OnObt?.Invoke();
			StartCoroutine(WaitInteract(onComp));
		}
	}

	//이외 액션들

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
		//여기서 이동시키고 
		Deactivate();
		PlayerCtrl.instance.DeMove();
		yield return new WaitForSeconds(interactTime);
		Activate();
		PlayerCtrl.instance.GoMove();
		onComp?.Invoke();
	}
}

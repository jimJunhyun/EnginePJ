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

	Canvas myRect;
	GlowAura myAura;
	Dictionary<AllInteractions, UnityAction<System.Action>> actions;
	int layer = 11;

	private void Awake()
	{
		myRect = GetComponentInChildren<Canvas>();
		myAura = GetComponent<GlowAura>();
		myAura.enabled = isInterable;
		myRect.enabled = isInterable;
		layer = 1 << layer;
		actions = new Dictionary<AllInteractions, UnityAction<System.Action>>{
			{ AllInteractions.Look,  Look},
			{ AllInteractions.Obtain, Obtain },

		};
		for (int i = 0; i < ableInters.Count; i++)
		{
			allActions.Add(actions[ableInters[i]]);
		}
	}

	public void Look(System.Action onComp)
	{
		if(isInterable && ableInters.Contains(AllInteractions.Look))
		{
			StartCoroutine(WaitInteract(true,OnLook, onComp));
		}
	}

	public void Obtain(System.Action onComp)
	{
		if (isInterable && ableInters.Contains(AllInteractions.Obtain))
		{
			StartCoroutine(WaitInteract(true, OnObt, onComp));
		}
	}

	//이외 액션들

	public void Deactivate()
	{
		isInterable = false;
		myRect.enabled = false;
		myAura.enabled = false;
	}
	public void Activate()
	{
		isInterable = true;
		myRect.enabled = true;
		myAura.enabled = true;
	}
	IEnumerator WaitInteract(bool toWait, UnityEvent act = null, System.Action onComp = null) 
	{
		PlayerCtrl.instance.clickPos = transform.position;
		
		yield return new WaitUntil(() => { return  Physics2D.CircleCast(transform.position, PlayerCtrl.instance.GetComponent<Interacter>().interDist, Vector2.zero, 0, layer);});
		PlayerCtrl.instance.DeMove();
		PlayerCtrl.instance.InteractAnim();
		Deactivate();
		if (toWait)
		{
			yield return new WaitForSeconds(interactTime);
		}
		Activate();
		act?.Invoke();
		PlayerCtrl.instance.GoMove();
		
		onComp?.Invoke();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterPanel : MonoBehaviour
{
    public List<DragEndFunc> invokeActers = new List<DragEndFunc>();
	public float fanTime;
	public float fanEndAngle;
	Interacts currentInteracting;
	RadialLayout radial;

	private void Awake()
	{
		radial = GetComponent<RadialLayout>();
	}
	private void Start()
	{
		OffPanel();
	}
	private void OnEnable()
	{
		GetComponentsInChildren(invokeActers);
		
	}

	public void OffPanel()
	{
		for (int i = 0; i < invokeActers.Count; i++)
		{
			invokeActers[i].OffImg();
		}
	}

	public void OnPanel()
	{
		for (int i = 0; i < invokeActers.Count; i++)
		{
			invokeActers[i].OnImg();
		}
		StartCoroutine(Fanning());
	}

	public void SetFuncs(GameObject interactee)
	{
		for (int i = 0; i < invokeActers.Count; i++)
		{
			invokeActers[i].myImg.enabled = false;
			invokeActers[i].uiLoader.myImg.enabled = false;
		}
		currentInteracting = interactee.GetComponent<Interacts>();
		for (int i = 0; i < currentInteracting.allActions.Count; i++)
		{
			invokeActers[i].myImg.enabled = true;
			invokeActers[i].uiLoader.myImg.enabled = true;
			invokeActers[i].uiLoader.SetImage(currentInteracting.ableInters[i]);
			invokeActers[i].OnMouseUp.RemoveAllListeners();
			invokeActers[i].OnMouseUp.AddListener(currentInteracting.allActions[i]);

		}
	}

	IEnumerator Fanning()
	{
		float curT = 0;
		while(fanTime >= curT)
		{
			yield return null;
			curT += Time.deltaTime;
			radial.MinAngle = Mathf.Lerp(0, fanEndAngle, curT / fanTime);
			
			for (int i = 0; i < invokeActers.Count; i++)
			{
				invokeActers[i].transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, -(360 / invokeActers.Count) * i, curT / fanTime));
			}
		}
		
	}
}

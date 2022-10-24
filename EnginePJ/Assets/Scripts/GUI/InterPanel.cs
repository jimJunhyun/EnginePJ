using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterPanel : MonoBehaviour
{
    public List<DragEndFunc> invokeActers = new List<DragEndFunc>();
	Interacts currentInteracting;
	private void Awake()
	{
		gameObject.SetActive(false);
	}
	private void OnEnable()
	{
		GetComponentsInChildren(invokeActers);
		for (int i = 0; i < invokeActers.Count; i++)
		{
			invokeActers[i].transform.rotation = Quaternion.Euler(0, 0, -(360 / invokeActers.Count) * i);
		}
	}

	public void SetFuncs(GameObject interactee)
	{
		currentInteracting = interactee.GetComponent<Interacts>();
		for (int i = 0; i < currentInteracting.allActions.Count; i++)
		{
			invokeActers[i].OnMouseUp.AddListener(currentInteracting.allActions[i]);
		}
	}
}

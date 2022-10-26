using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragEndFunc : MonoBehaviour
{
	public UnityEvent<System.Action> OnMouseUp;
	public Image myImg;
	public InteractionImage uiLoader;

	private void Awake()
	{
		myImg = GetComponent<Image>();
		uiLoader = GetComponentInChildren<InteractionImage>();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragEndFunc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public UnityEvent<System.Action> OnMouseUp;
	public Image myImg;
	public InteractionImage uiLoader;
	public GlowAura aura;

	Image uiImage;

	public void OnPointerEnter(PointerEventData eventData)
	{
		aura.OnLight();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		aura.OffLight();
	}

	private void Awake()
	{
		aura = GetComponent<GlowAura>();
		myImg = GetComponent<Image>();
		uiLoader = GetComponentInChildren<InteractionImage>();
		uiImage = uiLoader.GetComponent<Image>();
	}

	public void OffImg()
	{
		myImg.enabled = false;
		uiImage.enabled = false;
	}
	public void OnImg()
	{
		myImg.enabled = true;
		uiImage.enabled = true;
	}
}

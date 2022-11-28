using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BoxRule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	#region º¯¼ö
	public enum Symbols 
	{
		None = -1,
		
		Butterfly,
		Cat,
		Goat,
		Fish,

		Max
	}

	public float singleSymbolOffset = -0.23f;
	public float LerpMoveTime = 1f;

	public List<Symbols> matches;
	public UnityEvent onMatched;

	List<Switches> connected = new List<Switches>();
	bool matched;
	bool solved =false;

	bool focused = true;
	GameObject undermostPanel;
	#endregion
	private void Awake()
	{
		GetComponentsInChildren<Switches>(connected);
		undermostPanel = transform.parent.gameObject;
		solved = false;
	}
	private void Update()
	{
		if (!solved)
		{
			matched = true;
			for (int i = 0; i < connected.Count; i++)
			{
				matched &= (connected[i].curSymbol == ((int)matches[i]));
			}
			if (matched)
			{
				onMatched.Invoke();
				solved = true;
			}
		}
		if ((Input.GetMouseButtonDown(0) && !focused))
		{
			undermostPanel.SetActive(false);
		}
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		focused = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		focused = true;
	}
}

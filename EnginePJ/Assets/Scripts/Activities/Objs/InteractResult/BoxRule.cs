using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxRule : MonoBehaviour
{
	public enum Symbols 
	{
		None = -1,

		Circle,
		Rectangle,
		Triangle,
		Pentagon,
		Hexagon,

		Max
	}

	public List<Symbols> matches;
	public UnityEvent onMatched;

	List<Switches> connected = new List<Switches>();
	bool matched;
	bool solved =false;

	private void Awake()
	{
		GetComponentsInChildren<Switches>(connected);
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
		
	}
	public void TempF()
	{
		Debug.Log("¿­¾ú´Ù.");
	}
}

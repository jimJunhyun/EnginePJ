using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTempInter : MonoBehaviour
{
	Collider2D mycol;
	Collider2D glowcol;
	SpriteRenderer mysr;
	private void Awake()
	{
		mycol = GetComponent<Collider2D>();
		mysr = GetComponent<SpriteRenderer>();
		glowcol = GetComponentsInChildren<Collider2D>()[1];
	}
	public void Open()
	{
		mycol.enabled = false;
		mysr.enabled = false;
		glowcol.enabled = false;
	}
}

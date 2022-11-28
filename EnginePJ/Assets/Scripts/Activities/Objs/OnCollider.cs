using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollider : MonoBehaviour
{
	public int colLayer;
    public UnityEvent OnEnter;
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.layer == colLayer)
		{
			OnEnter.Invoke();
		}
	}
}

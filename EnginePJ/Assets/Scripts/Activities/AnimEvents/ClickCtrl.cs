using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickCtrl : MonoBehaviour
{
    public bool enable = false;
    public UnityEvent OnClick;
    public void Activate()
	{
        enable = true;
	}
    public void DeActivate()
	{
        enable = false;
	}
    // Update is called once per frame
    void Update()
    {
        if(enable && Input.GetMouseButtonDown(0))
		{
            OnClick.Invoke();
		}
    }
}

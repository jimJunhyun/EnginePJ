using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CinemaDirector : MonoBehaviour
{
	public List<UnityEvent> dircs;

	UpdateLights lightMan;
	ShowTxtOnDark textMan;
	MoveToPos moveMan;
	Conversation convMan;
	CameraTransition tranMan;

	int idx = 0;
	bool nextProceed = false;

	private void Awake()
	{
		lightMan = GetComponent<UpdateLights>();
		textMan = GetComponent<ShowTxtOnDark>();
		moveMan = GetComponent<MoveToPos>();
		convMan = GetComponent<Conversation>();
		tranMan = GetComponent<CameraTransition>();
	}

	private void Update()
	{
		nextProceed = (lightMan.isComp && textMan.isComp && moveMan.isComp && convMan.isComp && tranMan.isComp);
		if (((idx == 0 || nextProceed) && idx < dircs.Count))
		{
			lightMan.isComp = false;
			textMan.isComp = false;
			moveMan.isComp = false;
			convMan.isComp = false;
			tranMan.isComp = false;
			dircs[idx].Invoke();
			++idx;
		}
	}

}

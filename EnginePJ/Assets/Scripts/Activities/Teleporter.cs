using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public void Teleport(Transform telePos)
	{
		PlayerCtrl.instance.transform.position = telePos.position;
	}
}

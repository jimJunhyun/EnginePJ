using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	float del = 0;
	public void SetDel(float d)
	{
		del = d;
	}
    public void Teleport(Transform telePos)
	{
		StartCoroutine(DelTel(telePos));
	}
	IEnumerator DelTel(Transform pos)
	{
		yield return new WaitForSeconds(del);
		PlayerCtrl.instance.transform.position = pos.position;
	}
}

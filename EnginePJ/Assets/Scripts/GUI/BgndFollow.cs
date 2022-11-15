using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgndFollow : MonoBehaviour
{
	public float followRatio;
	Transform mainCam;
	Vector2 prevPos;
	Vector2 posDelta;
	//bool following = false;

	public void Awake()
	{
		mainCam = Camera.main.transform;
	}
	private void OnEnable()
	{
		transform.position = new Vector3(mainCam.position.x, transform.position.y);
	}
	void LateUpdate()
    {
		posDelta = (Vector2)mainCam.position - prevPos;
		prevPos = mainCam.position;
		transform.Translate(new Vector2(posDelta.x * followRatio, 0));
    }
}

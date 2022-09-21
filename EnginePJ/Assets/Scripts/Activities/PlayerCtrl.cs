using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;

    Vector2 clickPos;
    float dir;

    public float speed;
    bool movable = true;

	private void Awake()
	{
		instance = this;
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButton(0) && movable)
		{
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir = Mathf.Clamp(clickPos.x, -1, 1);
            transform.Translate(new Vector2(dir * speed * Time.deltaTime, 0));
        }
        
    }
    public void DeMove()
	{
        movable = false;
	}
    public void GoMove()
	{
        movable = true;
	}
    public void MoveDisable(float time)
	{
        StartCoroutine(DelayOnOff(time));
	}

    IEnumerator DelayOnOff(float time)
	{
        DeMove();
        yield return new WaitForSeconds(time);
        GoMove();
	}
}

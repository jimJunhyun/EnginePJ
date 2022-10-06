using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;

    Vector2 clickPos;
	Vector2 dir;

	Ray buttonCheck;

    public float speed;
	public float rayDist;
	public int layer;

	public float err;
    bool movable = true;
	float prevSpeed;
	Animator myAnim;

	private void Awake()
	{
		instance = this;
		clickPos = transform.position;
		prevSpeed = speed;
		myAnim = GetComponent<Animator>();
		layer = ~(1 << layer);
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButton(0))
		{
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dir = clickPos - (Vector2)transform.position;
			
        }
		buttonCheck = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.Log(Physics.Raycast(buttonCheck));
		if (Physics2D.Raycast(transform.position, new Vector2(dir.x, 0), rayDist, layer))
		{
			if(speed != 0)
			{
				prevSpeed = speed;
				speed = 0;
			}
			
		}
		else
		{
			speed = prevSpeed;
		}
		Move();
    }

	void Move()
	{
		
		if (movable)
		{
			float dirX;
			dir = clickPos - (Vector2)transform.position;
			if(dir.x > 0)
			{
				dirX = 1; 
				
			}
			else
			{
				dirX = -1;
			}
			myAnim.SetBool("Walking", true);
			myAnim.SetBool("Idling", false);
			if(Approximate(dir.x, 0, err))
			{
				dirX = 0;
				myAnim.SetBool("Walking", false);
				myAnim.SetBool("Idling", true);
			}
			transform.Translate(new Vector2(dirX * speed * Time.deltaTime, 0));
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

	public bool Approximate(float a, float b, float err)
	{
		return Mathf.Abs(a- b) < err;
	}
	public bool Approximate(Vector2 a, Vector2 b, float err)
	{
		return Approximate(a.x, b.x, err) && Approximate(a.y, b.y, err);
	}

}

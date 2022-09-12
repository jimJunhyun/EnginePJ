using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Vector2 clickPos;
    float dir;

    public float speed;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0))
		{
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir = Mathf.Clamp(clickPos.x, -1, 1);
            transform.Translate(new Vector2(dir * speed * Time.deltaTime, 0));
        }
        
    }
}

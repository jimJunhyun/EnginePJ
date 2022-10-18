using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	public static CursorManager instance;

    public float detectRange = 1;
    public int useLayer = 7;

	public Collider2D col;
	Collider2D prevCol;
	// Update is called once per frame
	private void Awake()
	{
		instance = this;
		useLayer = 1 << useLayer;
	}
	void Update()
    {
        col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), detectRange, useLayer);
		if(prevCol && col && col != prevCol)
		{
			prevCol.GetComponent<GlowAura>().OffLight();
			prevCol = null;
		}
		if (col)
		{
			col.GetComponent<GlowAura>().OnLight();
			prevCol = col;
		}
		else if(prevCol)
		{
			prevCol.GetComponent<GlowAura>().OffLight();
			prevCol = null;
		}
    }
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), detectRange);
	}
}

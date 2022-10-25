using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
	public static CursorManager instance;

    public float detectRange = 1;
    public int useLayer = 7;
    public int useLayer2 = 8;

	public Collider2D col;
	public bool hoveringUI;
	public bool hoveringAura;
	List<RaycastResult> results = new List<RaycastResult>();
	List<GlowAura> auras = new List<GlowAura>();
	PointerEventData data;
	Collider2D prevCol;
	
	// Update is called once per frame
	private void Awake()
	{
		instance = this;
		useLayer = 1 << useLayer;
		useLayer2 = 1 << useLayer2;
		useLayer |= useLayer2;
		data = new PointerEventData(EventSystem.current);
	}
	void Update()
    {
		data.position = Input.mousePosition;
		EventSystem.current.RaycastAll(data, results);
		for (int i = 0; i < results.Count; i++)
		{
			GlowAura ga;
			if (ga = results[i].gameObject.GetComponent<GlowAura>())
				auras.Add(ga);
		}

		hoveringAura = auras.Count >= 1;
		hoveringUI = results.Count >= 1;

        col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), detectRange, useLayer);
		if(prevCol && col && col != prevCol )
		{
			prevCol.GetComponent<GlowAura>().OffLight();
			prevCol = null;
		}
		if (col && !hoveringAura)
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

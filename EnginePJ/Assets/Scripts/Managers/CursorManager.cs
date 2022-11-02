using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
	public static CursorManager instance;

    public float detectRange = 1;
    public int useLayer = 7;
    public int useLayer2 = 8;

	public Collider2D col;
	public bool hoveringUI;
	List<RaycastResult> results = new List<RaycastResult>();
	List<GlowAura> auras = new List<GlowAura>();
	List<Image> images = new List<Image>();
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
			Image image;
			if((results[i].gameObject.layer != 7 && results[i].gameObject.layer != 8) && (image = results[i].gameObject.GetComponent<Image>()))
				images.Add(image);
		}
		hoveringUI = images.Count >= 1;

        col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), detectRange, useLayer);
		if(prevCol && col && col != prevCol )
		{
			prevCol.GetComponent<GlowAura>().OffLight();
			prevCol = null;
		}
		if (col && !hoveringUI)
		{
			col.GetComponent<GlowAura>().OnLight();
			prevCol = col;
		}
		else if(prevCol)
		{
			prevCol.GetComponent<GlowAura>().OffLight();
			prevCol = null;
		}
		images.Clear();
    }
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), detectRange);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlideInvoke : MonoBehaviour
{
    public List<Sprite> images;
	public UnityEvent onComp;

	Image img;
	private void Awake()
	{
		img = GetComponent<Image>();
	}
	public void StartInvoke(float t)
	{
		StartCoroutine(SeqInvoke(t));
	}
	IEnumerator SeqInvoke(float t)
	{
		yield return new WaitForSeconds(t);
		img.enabled = true;
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		for (int i = 0; i < images.Count; i++)
		{
			img.sprite = images[i];
			yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		}
		onComp.Invoke();
	}
}

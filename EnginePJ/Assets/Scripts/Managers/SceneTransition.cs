using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public float delay = 0f;
	public void SetDelay(float del)
	{
		delay = del;
	}
    public void Transite(string sceneName)
	{
		StartCoroutine(DelLoad(sceneName));
	}
	IEnumerator DelLoad(string sceneName)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}

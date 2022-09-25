using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public bool isComp;
    public float basicWait;
    public List<string> WordScripts;
    public List<float> TimeOffsets;

    int idx = 0;

    public void NextSerif()
	{
        StartCoroutine(DelaySerif());
	}

    IEnumerator DelaySerif()
	{
        yield return basicWait + TimeOffsets[idx];
	}
}

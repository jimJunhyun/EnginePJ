using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public bool isComp;
    public List<Transform> mover;
    public List<Transform> destine;

    int idx = 0;

    public void EmptyFunc()
    {
        isComp = true;
    }
    public void StartMove(float time)
	{
        StartCoroutine(MoveForTime(time));
	}

    IEnumerator MoveForTime(float t)
	{
        float curTime = 0;
        Vector3 initpos = mover[idx].position;
        while(curTime <= t)
		{
            yield return null;
            mover[idx].position = Vector3.Lerp(initpos, destine[idx].position, curTime / t);
            Debug.Log(mover[idx].position + " : " + curTime / t);
            curTime+= Time.deltaTime;
            
		}
        ++idx;
        isComp = true;
    }
}

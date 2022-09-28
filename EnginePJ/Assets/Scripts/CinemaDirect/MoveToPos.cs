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
    public void DelEmpFunc(float t)
    {
        StartCoroutine(DelayEmpty(t));
    }
    public void StartMove(float time)
	{
        StartCoroutine(MoveForTime(time));
	}
    IEnumerator DelayEmpty(float t)
    {
        yield return new WaitForSeconds(t);
        isComp = true;
    }
    IEnumerator MoveForTime(float t)
	{
        float curTime = 0;
        Vector3 initpos = mover[idx].position;
        while(curTime <= t)
		{
            yield return null;
            mover[idx].position = Vector3.Lerp(initpos, destine[idx].position, curTime / t);
            curTime+= Time.deltaTime;
            
		}
        ++idx;
        isComp = true;
    }
}

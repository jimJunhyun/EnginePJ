using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public List<Transform> mover;
    public List<Transform> destine;

    int idx = 0;
    public void StartMove(float time)
	{
        CinemaDirector.instance.processes += 1;
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
            curTime+= Time.deltaTime;
            
		}
        ++idx;
        CinemaDirector.instance.processes -= 1;
    }
}

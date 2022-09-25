using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public bool isComp;
    public List<Transform> mover;
    public List<Transform> destine;
    public List<float> moveTime;

    int idx = 0;

    public void StartMove()
	{
        StartCoroutine(MoveForTime());
	}

    IEnumerator MoveForTime()
	{
        float curTime = 0;
        while(curTime <= moveTime[idx])
		{
            curTime+= Time.deltaTime;
            mover[idx].position = Vector3.Lerp(mover[idx].position, destine[idx].position, curTime / moveTime[idx]);
            yield return null;
		}
        ++idx;
        isComp = true;
    }
}

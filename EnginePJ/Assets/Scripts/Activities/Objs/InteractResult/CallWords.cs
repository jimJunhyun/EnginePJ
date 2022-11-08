using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallWords : MonoBehaviour
{
    public List<string> strings;
    public UnityEvent<List<string>, UnityAction> SequenceSay;
    public UnityEvent OnCompInfos;

    public void InvokeSeq()
	{
        SequenceSay.Invoke(strings, ()=>{ OnCompInfos.Invoke(); });
	}
}

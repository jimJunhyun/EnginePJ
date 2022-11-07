using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallWords : MonoBehaviour
{
    public List<string> strings;
    public UnityEvent<List<string>, UnityAction> SequenceSay;

    public void InvokeSeq()
	{
        SequenceSay.Invoke(strings, ()=>{ PlayerCtrl.instance.ResetAnims("Calling"); });
	}
}

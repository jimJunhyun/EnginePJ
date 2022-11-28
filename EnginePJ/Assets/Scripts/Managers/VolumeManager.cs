using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    List<AudioSource> sources ;
	private void Awake()
	{
		sources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
	}
	public void ChangeVals(float val)
	{
		for (int i = 0; i < sources.Count; i++)
		{
			sources[i].volume = val;
		}
	}
}

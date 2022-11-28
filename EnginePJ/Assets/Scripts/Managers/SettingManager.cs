using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameObject SettingPanels;

    bool stat = false;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            SettingPanels.SetActive(!stat);
            stat = !stat;
		}
    }
}

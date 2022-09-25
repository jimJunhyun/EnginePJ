using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 rotPerSec;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotPerSec * Time.deltaTime);
    }
}

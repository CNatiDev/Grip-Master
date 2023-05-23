using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AssingCamera : MonoBehaviour
{
    public CinemachineVirtualCamera Vcam;

    void Start()
    {

        StartCoroutine(InvokeAfterTime(2));
    }
     IEnumerator InvokeAfterTime(int s)
    {
        yield return new WaitForSeconds(s);
        Vcam.Priority = 11;
    }
}

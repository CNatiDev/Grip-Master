using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InvokeEvent : MonoBehaviour
{
    public UnityEvent Event_1;
    public UnityEvent Event_2;
    public UnityEvent Event_3;
    public UnityEvent Event_4;
    public void InvokeEvent_N(int Event)
    {
        switch (Event)
        {
            case 1:
                Event_1.Invoke();
                break;
            case 2:
                Event_2.Invoke();
                break;
            case 3:
                Event_3.Invoke();
                break;
            case 4:
                Event_4.Invoke();
                break;

        }
    }
    public IEnumerator InvokeAfterTime(int s)
    {
        yield return new WaitForSeconds(s);
        InvokeEvent_N(1);
    }
    public void InvokeEvent1AT(int seconds)
    {
        StartCoroutine(InvokeAfterTime(seconds));
    }

}

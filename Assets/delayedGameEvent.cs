using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class delayedGameEvent : MonoBehaviour
{
    public UnityEvent ToExecuteOnDelay;
    public void waitSecondsThenExecute(float seconds)
    {
        StartCoroutine(delayedCall(seconds));
    }

    IEnumerator delayedCall(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ToExecuteOnDelay.Invoke();

    }
}

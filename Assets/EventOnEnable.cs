using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventOnEnable : MonoBehaviour
{
    public UnityEvent OnGameObjectEnable;

    private void OnEnable()
    {
        OnGameObjectEnable.Invoke();
    }
}

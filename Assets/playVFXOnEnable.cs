using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVFXOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildDisabler : MonoBehaviour
{
    public List<GameObject> PossibleGO;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < PossibleGO.Count; i++)
        {
            if(Random.value > 0.5f)
            {
                PossibleGO[i].SetActive(false);
            }
        }
    }

}

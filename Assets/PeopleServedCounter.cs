using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeopleServedCounter : MonoBehaviour
{
    public string textToAddLeft;
    public string textToAddRight;
    private int counter = 0;
    public TextMeshProUGUI target;


    private void OnEnable()
    {
        OrderingLogic.OnClientSatisfied += OrderingLogic_OnClientSatisfied;
    }

    private void OrderingLogic_OnClientSatisfied()
    {
        counter++;
        target.text = textToAddLeft + " " + counter.ToString() + " " + textToAddRight;
    }

    private void OnDisable()
    {
        OrderingLogic.OnClientSatisfied -= OrderingLogic_OnClientSatisfied;
    }
    

}

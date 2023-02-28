using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class ShowViewOnProximity : MonoBehaviour
{
    [SerializeField] private UIView ViewHolder;

    private void OnTriggerEnter(Collider other)
    {
        ViewHolder.Show();
    }

    private void OnTriggerExit(Collider other)
    {
        ViewHolder.Hide();
    }
}

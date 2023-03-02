using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableType pickupType;
    protected FoodPickupAndServe targetPickup;
    public virtual void TriggerInteract()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var pick = other.GetComponent<FoodPickupAndServe>();
        if (pick != null)
        {
            pick.AllowInteract(this);
            targetPickup = pick;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var pick = other.GetComponent<FoodPickupAndServe>();
        if (pick != null)
        {
            pick.DisallowInteract(this);
            targetPickup = null;
        }
    }

}

public enum InteractableType
{
    Table, Food
}
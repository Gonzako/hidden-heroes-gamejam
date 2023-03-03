using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableType pickupType;
    protected FoodPickupAndServe targetPickup;
    private bool pickedUp = false;
    public void TriggerInteract()
    {
        pickedUp = true;
        GetComponent<Collider>().enabled = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp)
        {
            return;
        }
        var pick = other.GetComponent<FoodPickupAndServe>();
        if (pick != null)
        {
            pick.AllowInteract(this);
            targetPickup = pick;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pickedUp)
        {
            return;
        }
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
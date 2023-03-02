using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodPickupAndServe : MonoBehaviour
{
    public UnityEvent OnAllowInteract;
    public UnityEvent OnLeaveInteract;
    public UnityEvent OnInteractActive;
    public UnityEvent OnStartHolding;

    public Transform PickupPoint;

    List<Interactable> FoodInteractables = new List<Interactable>();
    List<Interactable> TableInteractables = new List<Interactable>();

    private bool HoldingItem = false;
    private bool AllowedInteract => FoodInteractables.Count  > 0 || HoldingItem;
    private bool IsTableNearby => TableInteractables.Count > 0;
    private Interactable HeldFood;

    private void Start()
    {
    }


    public void AllowInteract(Interactable target)
    {
        if(target.pickupType == InteractableType.Food)
            FoodInteractables.Insert(0,target);
        if (target.pickupType == InteractableType.Table)
            TableInteractables.Insert(0, target);
    } 

    public void DisallowInteract(Interactable targetToRemove)
    {
        FoodInteractables.Remove(targetToRemove);
        TableInteractables.Remove(targetToRemove);
    }

    public void ActiveInteract()
    {
        if(!AllowedInteract)
        {
            return;
        }
        OnInteractActive.Invoke();
        if (HoldingItem)
        {
            if (IsTableNearby)
            {
                Debug.Log("Food served!");

                Destroy(HeldFood.transform.parent, 0.2f);
                //Serve logic
            }
            else
            {
                Destroy(HeldFood.transform.parent, 0.2f);
                //Drop logic
            }
            HoldingItem = false;
        }
        else
        {
            HoldingItem = true;
            //Pickup Logic
            var target = FoodInteractables[0].transform.parent;
            target.parent = PickupPoint;
            target.localPosition = Vector3.zero;
            HeldFood = FoodInteractables[0];
            OnStartHolding.Invoke();
        }

    }
    
    private enum PickupState
    {
        Holding, Pickup
    }
}


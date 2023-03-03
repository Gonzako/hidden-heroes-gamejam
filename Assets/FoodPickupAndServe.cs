using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FoodPickupAndServe : MonoBehaviour
{
    public UnityEvent OnStartHolding;
    public UnityEvent OnStopHolding;
    public UnityEvent OnEnablePickupPrompt;
    public UnityEvent OnDisablePickupPrompt;
    public UnityEvent OnEnableTableServePrompt;
    public UnityEvent OnDisableTableServePrompt;

    public Transform PickupPoint;

    List<Interactable> FoodInteractables = new List<Interactable>();
    List<Interactable> TableInteractables = new List<Interactable>();

    private bool HoldingItem { set { holdingItem = value; FoodPickupAndServe.IsHolding = value; } get => holdingItem; }
    private bool holdingItem;
    private bool AllowedInteract => FoodInteractables.Count  > 0 || HoldingItem;
    private bool IsTableNearby => TableInteractables.Count > 0;
    private Interactable HeldFood;
    public static bool IsHolding { private set; get; }
    private void Start()
    {
    }


    public void AllowInteract(Interactable target)
    {
        Debug.Log(target.transform.parent.name + " pickable.");
        if(target.pickupType == InteractableType.Food)
        {

            FoodInteractables.Insert(0, target);
            if (FoodInteractables.Count == 1)
            {
                Debug.Log("test");
                OnEnablePickupPrompt.Invoke();
            }
        }
        if (target.pickupType == InteractableType.Table && HoldingItem)
        {

            TableInteractables.Insert(0, target);
        }
    } 

    public void DisallowInteract(Interactable targetToRemove)
    {
        FoodInteractables.Remove(targetToRemove);
        TableInteractables.Remove(targetToRemove);
        if (HoldingItem)
        {
            if(TableInteractables.Count == 0)
            {
                OnDisableTableServePrompt.Invoke();
            }
        }
        else
        {
            if(FoodInteractables.Count == 0)
            {
                OnDisablePickupPrompt.Invoke();
            }
        }
    }

    public void ActiveInteract( InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx);
        if (!AllowedInteract)
        {
            return;
        }
        if (!ctx.performed)
        {
            return;
        }
        if (HoldingItem)
        {
            if (IsTableNearby)
            {
                Debug.Log("Food served!");

                HeldFood.transform.parent.parent = null;
                Destroy(HeldFood.transform.parent.gameObject, 1f);
                //Serve logic
            }
            else
            {
                Debug.Log("Food dropped");
                var rbs = HeldFood.transform.parent.GetComponentsInChildren<Rigidbody>();
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].isKinematic = false;
                    rbs[i].velocity = Random.insideUnitSphere;
                }
                Destroy(HeldFood.transform.parent.gameObject, 1f);

                HeldFood.transform.parent.parent = null;
                //Drop logic
            }
            HoldingItem = false;
            OnStopHolding.Invoke();
            FoodInteractables.Remove(HeldFood);
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

            OnDisablePickupPrompt.Invoke();
            if (TableInteractables.Count > 0)
            {
                OnEnableTableServePrompt.Invoke();
            }
        }

    }
    
    private enum PickupState
    {
        Holding, Pickup
    }
}


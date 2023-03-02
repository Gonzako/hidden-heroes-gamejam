using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodHolder : MonoBehaviour
{
    public static event Action<FoodItem> OnStartHoldingFood = null;
    public static event Action<FoodItem> OnStopHoldingFood  = null;
    public UnityEvent<Transform> OnRejectHoldedFood = new UnityEvent<Transform>();

    private Transform CurrentItem = null;
    private FoodItem CurrentFood = null;
    public void RecieveFood(Transform Item)
    {
        if(CurrentItem != null)
        {
            RejectHoldedfood();
        }
        CurrentItem = Item;
        CurrentFood = Item.GetComponentInChildren<FoodItem>();
        OnStartHoldingFood?.Invoke(CurrentFood);
    }

    public void RejectHoldedfood()
    {

        OnRejectHoldedFood.Invoke(CurrentItem);
        CurrentFood = null;
        CurrentItem = null;
    }

    public FoodItem ServeFood()
    {
        OnStopHoldingFood.Invoke(CurrentFood);

        return CurrentFood;
    }
}

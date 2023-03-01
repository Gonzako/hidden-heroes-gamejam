using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenOrderer : MonoBehaviour
{
    [SerializeField] private GameObject FoodPrefab;
    public static event Action<GameObject> OnOrderFood = null;

    public void StartFoodOrder()
    {
        OnOrderFood?.Invoke(FoodPrefab);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    private void OnEnable()
    {
        KitchenOrderer.OnOrderFood += KitchenOrderer_OnOrderFood;
    }

    private void KitchenOrderer_OnOrderFood(GameObject obj)
    {
        Instantiate(obj, this.transform.position,Quaternion.identity);
    }

    private void OnDisable()
    {
        KitchenOrderer.OnOrderFood -= KitchenOrderer_OnOrderFood;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{
    public UnityEvent OnFoodOrdered;
    
    private void OnEnable()
    {
        KitchenOrderer.OnOrderFood += KitchenOrderer_OnOrderFood;
    }

    private void KitchenOrderer_OnOrderFood(GameObject obj)
    {
        Debug.Log("test");
        var posToSpawn = this.transform.position;// + Random.insideUnitSphere;
        posToSpawn.y = transform.position.y;
        Instantiate(obj, posToSpawn,Quaternion.identity);
        OnFoodOrdered.Invoke();
    }

    private void OnDisable()
    {
        KitchenOrderer.OnOrderFood -= KitchenOrderer_OnOrderFood;
    }
}

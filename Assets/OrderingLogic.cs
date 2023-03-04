using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingLogic : MonoBehaviour
{
    public List<Transform> SpriteToSpawn;
    public List<Transform> ReactionToShow;
    private void Start()
    {
        
    }

    private IEnumerator OrderingSpawn()
    {
        yield return null;
    }

    public void RecieveFood(FoodItem dish)
    {

    }
}

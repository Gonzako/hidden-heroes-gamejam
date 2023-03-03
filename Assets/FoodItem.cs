using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public ServableFood TargetFood;
}

public enum ServableFood
{
    Gazpacho, FriedRice, Kebab, Pasta, Salad
}
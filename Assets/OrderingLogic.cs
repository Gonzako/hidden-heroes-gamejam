using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class OrderingLogic : MonoBehaviour
{
    public List<Transform> SpriteToSpawn;
    public List<Transform> ReactionToShow;
    public List<Transform> ClientsToShow;
    public static event Action<OrderingLogic> OnClientSpawn = null;
    public static event Action<OrderingLogic> OnClientDespawn = null;
    [SerializeField]
    private UIView ReactionView;
    [SerializeField]
    private UIView OrderView;
    private ServableFood DesiredDish;
    private float TimeWhenCreated;
    private void Start()
    {
        TurnOffClient();
        StartCoroutine(OrderingSpawn());
    }

    private IEnumerator OrderingSpawn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.value * 30f);
        if(ClientSpawnThrottler.AreMoreClientsAllowed)
        { 
            DesiredDish = (ServableFood)UnityEngine.Random.Range(0, 5);
            SpriteToSpawn[(int)DesiredDish].gameObject.SetActive(true);
            ClientsToShow[UnityEngine.Random.Range(0, ClientsToShow.Count)].gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            TimeWhenCreated = Time.time;
            OnClientSpawn?.Invoke(this);
        }
        else
        {
            StartCoroutine(OrderingSpawn());
        }
    }

    public void RecieveFood(FoodItem dish)
    {
        if(dish.TargetFood == DesiredDish)
        {
            ReactionToShow[UnityEngine.Random.Range(0, 2)].gameObject.SetActive(true);
        }
        else
        {
            ReactionToShow[UnityEngine.Random.Range(2, 4)].gameObject.SetActive(true);
        }
        ReactionView.Show();
        OrderView.Hide();
        Invoke("TurnOffClient", 5f);
        OnClientDespawn?.Invoke(this);
        StartCoroutine(OrderingSpawn());
    }

    private void TurnOffClient()
    {
        for (int i = 0; i < SpriteToSpawn.Count; i++)
        {
            SpriteToSpawn[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ClientsToShow.Count; i++)
        {
            ClientsToShow[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ReactionToShow.Count; i++)
        {
            ReactionToShow[i].gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

}

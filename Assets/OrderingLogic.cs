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
        yield return new WaitForSeconds(UnityEngine.Random.value*30f);
        DesiredDish = (ServableFood)UnityEngine.Random.Range(0, 5);
        SpriteToSpawn[(int)DesiredDish].gameObject.SetActive(true);
        ClientsToShow[UnityEngine.Random.Range(0, ClientsToShow.Count)].gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        TimeWhenCreated = Time.time;
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
        StartCoroutine(DelayedHide());
        Invoke("TurnOffClient", 5f);
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

    private IEnumerator DelayedHide()
    {
        yield return new WaitForSeconds(2.5f);
        OrderView.Hide();
    }
}

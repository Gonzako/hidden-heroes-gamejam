using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnThrottler : MonoBehaviour
{
    public static bool AreMoreClientsAllowed { get; private set; }

    public int MaxClientsAllowed = 5;
    //public int ClientsPerTimeAllowed = 1;
    private List<OrderingLogic> SpawnedClients = new List<OrderingLogic>();

    public float TimeBetweenSpawnAdd = 60;
    private float NextTime;
    private void OnEnable()
    {
        AreMoreClientsAllowed = true;
        OrderingLogic.OnClientDespawn += OrderingLogic_OnClientDespawn;
        OrderingLogic.OnClientSpawn += OrderingLogic_OnClientSpawn;
        NextTime = Time.time + TimeBetweenSpawnAdd;
    }

    private void OrderingLogic_OnClientSpawn(OrderingLogic obj)
    {
        SpawnedClients.Add(obj);
        if(MaxClientsAllowed <= SpawnedClients.Count)
        {
            AreMoreClientsAllowed = false;
        }
    }

    private void OrderingLogic_OnClientDespawn(OrderingLogic obj)
    {
        SpawnedClients.Remove(obj);
        if (MaxClientsAllowed > SpawnedClients.Count)
        {
            AreMoreClientsAllowed = true;
        }
    }

    private void OnDisable()
    {

        OrderingLogic.OnClientDespawn -= OrderingLogic_OnClientDespawn;
        OrderingLogic.OnClientSpawn -= OrderingLogic_OnClientSpawn;
    }

    private void Update()
    {
        if(NextTime < Time.time)
        {
            MaxClientsAllowed++;
            if (MaxClientsAllowed > SpawnedClients.Count)
            {
                AreMoreClientsAllowed = true;
            }
            NextTime = Time.time + TimeBetweenSpawnAdd;
            TimeBetweenSpawnAdd -= 10f;
            TimeBetweenSpawnAdd = Mathf.Clamp(TimeBetweenSpawnAdd, 5f, 20000f);
        }
    }
}

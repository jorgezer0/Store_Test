using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorManager : MonoBehaviour
{
    public enum Destination
    {
        Outside,
        Store
    }

    [SerializeField] private Transform player;
    
    [SerializeField] private GameObject outside;
    [SerializeField] private Transform outsideSpawnPoint;
    [SerializeField] private GameObject store;
    [SerializeField] private Transform storeSpawnPoint;

    private void Start()
    {
        store.SetActive(false);
    }

    public void TrespassDoor(Destination destination)
    {
        switch (destination)
        {
            case Destination.Outside:
                outside.SetActive(true);
                store.SetActive(false);
                player.SetPositionAndRotation(outsideSpawnPoint.position, Quaternion.identity);
                break;
            case Destination.Store:
                outside.SetActive(false);
                store.SetActive(true);
                player.SetPositionAndRotation(storeSpawnPoint.position, Quaternion.identity);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination), destination, null);
        }
    }
}

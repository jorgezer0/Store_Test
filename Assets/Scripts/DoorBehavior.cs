using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private DoorManager.Destination destination;
    private DoorManager doorManager;

    private void Start()
    {
        doorManager = FindObjectOfType<DoorManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            doorManager.TrespassDoor(destination);
        }
    }
}

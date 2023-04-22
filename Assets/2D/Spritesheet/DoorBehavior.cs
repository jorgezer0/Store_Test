using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private DoorManager.Destination destination;
    private DoorManager _doorManager;

    private void Start()
    {
        _doorManager = FindObjectOfType<DoorManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            _doorManager.TrespassDoor(destination);
        }
    }
}

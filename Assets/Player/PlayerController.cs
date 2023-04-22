using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float moveSpeed = 1;
    
    private Vector2 movementInput;
    private bool nearNpc;
    private bool talking;
    private NpcBehavior npc;

    private void FixedUpdate()
    {
        if (!talking)
            _rigidbody.MovePosition(_rigidbody.position + (movementInput * Time.fixedDeltaTime * moveSpeed));
    }

    //Method called from the Input System
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    //Method called from the Input System
    private void OnInteract(InputValue inputValue)
    {
        if (!npc) return;
        if (talking) return;
        
        talking = true;
        npc.StartDialogue();
        npc.onDialogueComplete.AddListener(OnDialogueComplete);
    }

    private void OnDialogueComplete()
    {
        talking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        nearNpc = other.CompareTag("Npc");

        if (nearNpc)
            npc = other.GetComponent<NpcBehavior>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        npc = null;
    }
}

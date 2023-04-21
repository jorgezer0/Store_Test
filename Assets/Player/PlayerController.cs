using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float moveSpeed = 1;
    
    private Vector2 _movementInput;
    private bool nearNpc;
    private bool talking;
    private NpcBehavior npc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!talking)
            _rigidbody.MovePosition(_rigidbody.position + (_movementInput * Time.fixedDeltaTime * moveSpeed));
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void OnInteract(InputValue inputValue)
    {
        if (npc)
        {
            if (!talking)
            {
                talking = true;
                npc.StartDialogue();
                npc.onDialogueComplete.AddListener(OnDialogueComplete);
            }
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NpcBehavior : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    [SerializeField] private string startNode;

    public UnityEvent onDialogueComplete;
    
    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }
    
    public void StartDialogue()
    {
        dialogueRunner.StartDialogue(startNode);
        dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
    }

    private void OnDialogueComplete()
    {
        onDialogueComplete.Invoke();
    }
}

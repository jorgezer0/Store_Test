using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NpcBehavior : MonoBehaviour
{
    private DialogueRunner _dialogueRunner;
    [SerializeField] private string startNode;

    public UnityEvent onDialogueComplete;
    
    private void Start()
    {
        _dialogueRunner = FindObjectOfType<DialogueRunner>();
    }
    
    public void StartDialogue()
    {
        _dialogueRunner.StartDialogue(startNode);
        _dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
    }

    private void OnDialogueComplete()
    {
        onDialogueComplete.Invoke();
    }
}

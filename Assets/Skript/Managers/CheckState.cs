using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CheckState : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private DialogueManager dialogueManager;

    private InputActionMap dialogueMap;
    private InputActionMap playerMap;
    private InputActionMap itemMap;
    

    private void Awake()
    {
        dialogueMap = playerInput.actions.FindActionMap("Dialogue");
        playerMap = playerInput.actions.FindActionMap("Player");
        itemMap = playerInput.actions.FindActionMap("Item");
    }
    
    public void ActivateDialogueMap()
    {
            dialogueMap.Enable();
            playerMap.Disable();
    }

    public void ActivatePlayerMap()
    {
        playerMap.Enable();
        dialogueMap.Disable();
    }

    public void ActivateItemMap()
    {
        playerMap.Disable();
        itemMap.Enable();
        
    }
    
}

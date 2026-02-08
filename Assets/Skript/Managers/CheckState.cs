using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CheckState : MonoBehaviour
{
    // In this method we want to look for each Action Map which we can later turn on or off.
    // This allows us to toggle the interaction for specific scenarios. 
    // The player Map is the main Map. This includes Walking and Interaction.
    // The item Map controlls all item logic and allows us the lock movement and toggle items/events.
    // The dialogue map is our standard map for everything related to dialogs and only allows us to continue the dialog OR select dialog choices.

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

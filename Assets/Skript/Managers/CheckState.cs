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
    private InputActionMap repeatedInputMap;
    private InputActionMap animationMap;
    

    private void Awake() 
    {
        dialogueMap = playerInput.actions.FindActionMap("Dialogue");
        playerMap = playerInput.actions.FindActionMap("Player");
        itemMap = playerInput.actions.FindActionMap("Item");
        repeatedInputMap = playerInput.actions.FindActionMap("MiniGame");
        animationMap = playerInput.actions.FindActionMap("Animation");
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
        repeatedInputMap.Disable();
    }

    public void ActivateItemMap()
    {
        animationMap.Disable();
        dialogueMap.Disable();
        repeatedInputMap.Disable();
        playerMap.Disable();
        itemMap.Enable();
    }

    public void ActivateRepeatedInputMap()
    {
        playerMap.Disable();
        dialogueMap.Disable();
        itemMap.Disable();
        repeatedInputMap.Enable();
    }
    
    public void ActivateAnimationMap()
    {
        playerMap.Disable();
        dialogueMap.Disable();
        itemMap.Disable();
        animationMap.Enable();
    }
}

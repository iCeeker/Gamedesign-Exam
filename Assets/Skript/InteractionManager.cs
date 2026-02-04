    using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject interactedItem;
    [SerializeField] private GameObject interactionObject;
    
    private bool hasBeenInteracted = false;
    
    [SerializeField] private CheckState checkState;
    
    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
    
    public void Interact() // Depending on Object Tag we're having different forms of interaction
    {
        Debug.Log("Interacted");

        if (CompareTag("Collectable")) // We're increasing our collection counter 
        {
            Debug.Log("Collectable");
        }
        
        if (CompareTag("NPC")) // We're starting an conversation
        {
            Debug.Log("NPC");
        }
        
        if (CompareTag("Item")) // We're interacting with an Item to open another menu
        {
            InteractWithItem();
        }
        
        if (!hasBeenInteracted)
        {
            hasBeenInteracted = true;
        }
    }

    private void InteractWithItem()
    {
        if (interactedItem != null)
        {
            interactedItem.SetActive(true);
            hasBeenInteracted = true;
            
            checkState.DisablePlayerInput();
        }
        else { return; }
    }

    public void InteractWithNpc()
    {
        // Start Talking with NPC
    }

    public void InteractWithCollectable()
    {
        // Reference a Value
        // Increase Item Collection Counter +1 
    }
}

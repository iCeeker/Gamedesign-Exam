using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionChecker : MonoBehaviour
{
    private IInteraction interactionInRange = null;
    [SerializeField] private GameObject interactionObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        interactionObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteraction interaction) && interaction.IsInteractable()) // looking for IInteraction and checking if it's interactable, if yes, activate the indicator
                                                                                                 // (need this, because we have a trigger map border for camera check)
        {
            interactionInRange = interaction;
            interactionObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteraction interaction) && interaction == interactionInRange) // after leaving the range, we're turning off the indicator
        {
            interactionInRange = null;
            interactionObject.SetActive(false);
        }
    }

    public void OnInteraction(InputAction.CallbackContext context) // on pressing the callback context key (in our case the F key) we're interacting
    {
        if (context.performed)
        {
            interactionInRange?.Interact(); // if the object is in range of the set interaction range zone, we're starting to interact
            interactionObject.SetActive(false); // Disable the interaction icon, since we can no longer interact (mostly using this because 99% of our stuff will be one shots)
        }
    }
}

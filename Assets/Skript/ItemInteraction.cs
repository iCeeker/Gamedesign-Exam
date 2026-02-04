using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject interactedItem;
    [SerializeField] private GameObject interactionObject;
    
    private bool hasBeenInteracted = false;
    
    [SerializeField] private CheckState checkState;
 
    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }

    public void Interact()
    {
        if (interactedItem != null)
        {
            interactedItem.SetActive(true);
            hasBeenInteracted = true;
            
            checkState.DisablePlayerInput();
        }
        else { return; }
    }
}

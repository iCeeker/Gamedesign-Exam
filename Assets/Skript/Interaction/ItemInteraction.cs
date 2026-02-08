using System;
using UnityEditor;
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
            if (interactionObject.activeSelf == true)
            {
                interactionObject.SetActive(false);
            }
            
            interactedItem.SetActive(true);
         //   hasBeenInteracted = true;
            
            checkState.ActivateItemMap();
        }
        else { return; }
    }
}

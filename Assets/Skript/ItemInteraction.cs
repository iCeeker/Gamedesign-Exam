    using System;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    private bool hasBeenInteracted = false;
    
    
    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
    
    public void Interact()
    {
        if (!hasBeenInteracted)
        {
            hasBeenInteracted = true;
            
        }
    }
    
}

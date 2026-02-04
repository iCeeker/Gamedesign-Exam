using UnityEngine;

public class CollectableInteraction : MonoBehaviour, IInteraction
{
    
    [SerializeField] CollectionTracker tracker;
    [SerializeField] private SO_Item soItem;
    
    private bool hasBeenInteracted = false;
    
    /* Start Find Gameobject that collects the data of the amount of collected collectables
     * On Interact, increase the amount of collectable depending on the type of collectable
     * delete this game object
     */ 
    public void Interact()
    { 
        IncreaseItemAmount();
       this.gameObject.SetActive(false);
    }

    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
    
    public void IncreaseItemAmount()
    {
        if (soItem.type == Type.Plank)
        {
            tracker.plankAmount =+ soItem.amount;
            // return feedback via txt that you found a plank
        }

        if (soItem.type == Type.Hammer)
        {
            tracker.hammerAmount =+ soItem.amount;
            // return feedback via txt that you found a hammer
        }

        if (soItem.type == Type.Nail)
        {
            tracker.nailAmount =+ soItem.amount;
            // return feedback via txt that you found a nail
        }
    }
}

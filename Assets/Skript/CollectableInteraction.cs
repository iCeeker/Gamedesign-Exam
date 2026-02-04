using UnityEngine;

public class CollectableInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] CollectionTracker tracker;
    
    private bool hasBeenInteracted = false;
    
    /* Start Find Gameobject that collects the data of the amount of collected collectables
     * On Interact, increase the amount of collectable depending on the type of collectable
     * delete this game object
     */ 
    public void Interact()
    {
   //    tracker.IncreaseItemAmount();
       this.gameObject.SetActive(false);
    }

    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class NpcInteraction : MonoBehaviour, IInteraction
{
    private bool hasBeenInteracted = false;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private DialogueManager dialogueManager;

    public void Interact()
    { 
        Debug.Log("We Interacted");
       DialogueManager.GetInstance().StartDialogue(textAsset);
    }

    public bool IsInteractable()    
    {
        return !hasBeenInteracted;
    }
}

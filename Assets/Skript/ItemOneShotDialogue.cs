using System;
using UnityEngine;

public class ItemOneShotDialogue : MonoBehaviour, IInteraction
{
    // Used for the beer interaction
    // We have a dialog pop up and then disable the item
    
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private QuestMain questMain;
    
    [SerializeField] bool hasBeenInteracted;

    private void Update()
    {
        if (dialogueManager.dialogueIsPlaying && hasBeenInteracted)
        {
            gameObject.SetActive(false);
            questMain.CompleteQuest();
            Debug.Log("Done");
        }
    }

    public void Interact()
    {
       DialogueManager.GetInstance().StartDialogue(textAsset);
    }

    public bool IsInteractable()
    {
        return hasBeenInteracted;
    }
}

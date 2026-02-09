using System;
using UnityEngine;

public class ItemDialogue : MonoBehaviour, IInteraction
{
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

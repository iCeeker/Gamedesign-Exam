using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject interactedItem;
    [SerializeField] private GameObject interactionIcon;
    [SerializeField] private bool hasDialogue;
    [SerializeField] private bool loadsScene;
    [SerializeField] private string sceneName;
    
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] TextAsset textAsset;
    
    [SerializeField] private QuestMain questMain;
    [SerializeField] private bool isAQuest;
    
    private bool hasBeenInteracted = false;
    
    [SerializeField] private CheckState checkState;
    
    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }

    public void Interact()
    {
        Debug.Log("Has Been interacted");
        
        if (hasDialogue == true)
        {
            Debug.Log("Has Dialogue");
            dialogueManager.StartDialogue(textAsset);
        }

        if (hasDialogue && isAQuest)
        {
            dialogueManager.StartDialogue(textAsset);
            questMain.CompleteQuest();
        }

        if (loadsScene)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        if (interactedItem != null)
        {
            if (interactionIcon.activeSelf == true)
            {
                interactionIcon.SetActive(false);
            }
            
            {
                Debug.Log("No Dialogue");
                interactedItem.SetActive(true);
                //   hasBeenInteracted = true;
            
                checkState.ActivateItemMap();
            }
        }
        else { return; }
    }
}

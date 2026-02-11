using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject interactedItem;
    [SerializeField] private GameObject interactionIcon;
    [SerializeField] private bool hasDialogue;
    [SerializeField] private bool opensDialogueFirst;
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
        
        if (hasDialogue && !isAQuest && interactedItem == null) // trigger if only has a dialogue
        {
            Debug.Log("Has Dialogue");
            dialogueManager.StartDialogue(textAsset);
        }

        if (hasDialogue && isAQuest && interactedItem == null) // trigger when it has a dialogue and is a quest
        {
            Debug.Log("Has Dialogue and is a quest");
            dialogueManager.StartDialogue(textAsset);
            questMain.CompleteQuest();
        }

        if (loadsScene) // trigger to load a scene
        {
            Debug.Log("Loading scene");
            SceneManager.LoadScene(sceneName);
        }
        
        if (interactedItem != null && hasDialogue) // trigger when we want a dialogue first and then interact with the item
        {
            if (opensDialogueFirst)
            {
                Debug.Log("Has Dialogue and item");
                dialogueManager.StartDialogue(textAsset);
            
                StartCoroutine(OpenItemAfter());
            }
            else
            {
                if (interactionIcon.activeSelf)
                {
                    interactionIcon.SetActive(false);
                }
        
                interactedItem.SetActive(true);
                checkState.ActivateItemMap();
                
                StartCoroutine(OpenItemBefore());
            }
          
        }
        
        if (interactedItem != null && !hasDialogue) // trigger if we only want to interact with it
        {
            if (interactionIcon.activeSelf)
            {
                interactionIcon.SetActive(false);
            }
            
            {
                interactedItem.SetActive(true);
                checkState.ActivateItemMap();
            }
        }
        else { return; }
    }

    private IEnumerator OpenItemAfter()
    {
        Debug.Log("Entered Coroutine");
        yield return new WaitUntil( () => !dialogueManager.dialogueIsPlaying);
        
        
        if (interactionIcon.activeSelf)
        {
            interactionIcon.SetActive(false);
        }
        
        interactedItem.SetActive(true);
        checkState.ActivateItemMap();
    }
    
    

    private IEnumerator OpenItemBefore()
    {
        yield return new WaitUntil( () => interactedItem.activeSelf == false);
     
        dialogueManager.StartDialogue(textAsset);
    }
}

using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ItemInteraction : MonoBehaviour, IInteraction
{
    [Header("Interactions with the Item")]
    [Tooltip("This is the Item which will get activated")]
    [SerializeField] private GameObject interactedItem;
    [Tooltip("Shows the interaction Icon on the player")]
    [SerializeField] private GameObject interactionIcon;
    [Tooltip("Gives info if the interaction will have a dialogue")]
    [SerializeField] private bool hasDialogue;
    [Tooltip("Choose if you want to have the Dialogue active before the item")]
    [SerializeField] private bool opensDialogueFirst;
    [Tooltip("Choose if you want to load a Scene after interaction (e.g. doors)")]
    [SerializeField] private bool loadsScene;
    [Tooltip("Choose which Scene you want to load. WARNING: Case Sensitive")]
    [SerializeField] private string sceneName;
    
    [Header("Dialogue Options")]
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] TextAsset textAsset;

    [Header("Quest Options")]
    [Tooltip("This is the Questbox which displays the UI Text")] 
    [SerializeField] private GameObject questUI;
    [Tooltip("This is the Quest Logic, to track quest Progress")]
    [SerializeField] private QuestMain questMain;
    [Tooltip("Check if this Item progresses the Quest")]
    [SerializeField] private bool isAQuest;
    
    [Header("State Logic")]
    [SerializeField] private CheckState checkState;

    [Header("Journal")] 
    [SerializeField] private bool hasKeypad;
    [SerializeField] private KeypadLogic keypadGameObject;
    
    [Tooltip("Disable after interacting with it")]
    private bool hasBeenInteracted = false;
    
    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }

    public void Interact()
    {
        if (hasKeypad)
        {
            foreach (var button in keypadGameObject.buttons)
            {
                button.SetActive(true);
            }
            keypadGameObject.errorCode.SetActive(false);
        }
        
        
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
                
                questUI.SetActive(false); 
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
        
        questUI.SetActive(false);  
        
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

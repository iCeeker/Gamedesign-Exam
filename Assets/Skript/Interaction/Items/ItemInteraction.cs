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

    [Header("Audio")] 
    [SerializeField] private bool playAudio;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
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

    [Header("Keypad")] 
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
            PlayAudio();
        }
        
        Debug.Log("Has Been interacted");
        
        if (hasDialogue && !isAQuest && interactedItem == null) // trigger if only has a dialogue
        {
            PlayAudio();
            Debug.Log("Has Dialogue");
            dialogueManager.StartDialogue(textAsset);
        }

        if (hasDialogue && isAQuest && interactedItem == null) // trigger when it has a dialogue and is a quest
        {
            PlayAudio();
            Debug.Log("Has Dialogue and is a quest");
            dialogueManager.StartDialogue(textAsset);
            questMain.CompleteQuest();
        }

        if (loadsScene) // trigger to load a scene
        {
            PlayAudio();
            Debug.Log("Loading scene");
            SceneManager.LoadScene(sceneName);
        }
        
        if (interactedItem != null && hasDialogue) // trigger when we want a dialogue first and then interact with the item
        {
            Debug.Log("Its that");
            PlayAudio();
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
            Debug.Log("Its this");
            
            if (interactionIcon.activeSelf)
            {
                interactionIcon.SetActive(false);
            }
            
            {
                interactedItem.SetActive(true);
                checkState.ActivateItemMap();
            }
        }
        
        if (interactedItem != null && hasDialogue) // trigger when we want a dialogue first and then interact with the item
        {
            if (isAQuest)
            {
                questMain.CompleteQuest();
            }
            
            PlayAudio();
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

    private void PlayAudio()
    {
        if (playAudio)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}

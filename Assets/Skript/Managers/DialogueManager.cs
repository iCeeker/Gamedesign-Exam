using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePrefab;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    private static DialogueManager instance;
    
    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    [SerializeField] private CheckState checkState;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("Found more than one instance of DialogueManager"); 
        }
        instance = this;
    }

    public static DialogueManager GetInstance() 
    {
        return instance;
    }
    
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePrefab.SetActive(false);
    }

    private void Update() 
    {
        if (!dialogueIsPlaying)
        {return;}

        if (InputManager.GetInstance().SubmitPressed()) // we're checking if we have pressed the continue button (space)
        {
            ContinueStory();
        }
        
    }

    public void StartDialogue(TextAsset textAsset)
    {
        checkState.ActivateDialogueMap(); // Starting a dialog by disabling all inputs the player has which we don't want (such as moving or interacting
        
        currentStory = new Story(textAsset.text); // We're creating a new story with the input we give 
        dialogueIsPlaying = true;
        dialoguePrefab.SetActive(true);
       
        ContinueStory(); 
    }

    private void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialoguePrefab.SetActive(false);
        dialogueText.text = "";
        
        checkState.ActivatePlayerMap(); // we reenable all inputs the player usually has
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue) // if the story has more than one line, we open a new dialog window
        {
            dialogueText.text = currentStory.Continue(); // Gives the next line of dialogue in the ink file
        }
        else
        {
            ExitDialogue();
        }
    }
}

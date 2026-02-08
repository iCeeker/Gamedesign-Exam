using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    // The Dialogue Manager controls everything that's related to dialogs.
    // Here we start, continue and end dialogs, add choices and also in a specific case add a certain value to the choice.
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePrefab;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;
    
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
        
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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
            DisplayChoices();
        }
        else
        {
            ExitDialogue();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.Log("There are too many choices");
        }

        int index = 0;
        // enable and initalize the chocies up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // The Unity Even System seems to be weird. It has to clear its cache first, wait for a frame and only then we can add our current object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakingAChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
}

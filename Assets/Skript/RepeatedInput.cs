using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Minigame 3 where we have to throw over something. 
// Game is beeing played by pressing space a number of times.
// The challenge: The value constantly goes down, so you have to press space a lot!

public class RepeatedInput : MonoBehaviour
{
    [Header("Other Objects & Scripts")]
    [SerializeField] private CheckState checkState;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TextAsset textAsset;
    private InputAction action;
    [SerializeField] private AudioSource audioSource;
     
    [Header("UI + Gameobject")]
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject miniGameobject;
    [SerializeField] private Button spaceButton;

    [Header("Slider Values")]
    [SerializeField] private float sliderReduction;
    [SerializeField] private float sliderIncrease;
    [SerializeField] private float sliderGoal;

    [Header("Results of Objects")] 
    [SerializeField] private GameObject previousObject;
    [SerializeField] private GameObject objectToInteractWith;
    [SerializeField] private AudioClip audioClip;
    
    private void Awake()
    {
        slider.value = 0;
        slider.maxValue = sliderGoal;
        miniGameobject.SetActive(true);
    }

    private void Start()
    {
        checkState.ActivateRepeatedInputMap();
        Debug.Log("activated Repeated Map");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slider.value);

        slider.value -= sliderReduction; // tried with *Time.deltaTime but unable to make it work. Cheesed it by having high sliderGoal + Increase values
    }

    public void IncreaseSliderValue(InputAction.CallbackContext context)
    {
        Debug.Log("Entered the IncreaseSliderValue"); 
        
        if (miniGameobject.activeSelf == true)
        {
            /*
            spaceButton.interactable = true;
            spaceButton.onClick.Invoke();           // Tried to make a color transition but didnt work
            spaceButton.interactable = false;
            */
            
            
            if (!context.performed) return;
            slider.value += sliderIncrease;
        
            Debug.Log("Increased slider");
            
            if (slider.value >= sliderGoal)
            {
                EndRepeatedInput();
            }
        }
    }

    private void EndRepeatedInput()
    {
        miniGameobject.SetActive(false);
        previousObject.SetActive(false);

        if (objectToInteractWith != null)
        {
            objectToInteractWith.SetActive(true);
            audioSource.PlayOneShot(audioClip); // Playing a sound for our interaction like throwing something over
            
        }
        checkState.ActivatePlayerMap();
        
        dialogueManager.StartDialogue(textAsset);
    }
}

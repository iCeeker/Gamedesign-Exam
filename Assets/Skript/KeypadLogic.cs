using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadLogic : MonoBehaviour
{
    [Header("Keypad UI")]
    [SerializeField] private TextMeshProUGUI screen;
    [SerializeField] private string codeWord;
    [SerializeField] private int codeLength;
    [SerializeField] private GameObject keypad;
    [SerializeField] private string sceneName;
    public GameObject errorCode;
    public GameObject[] buttons;
    
    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip errorAudioClip;
    [SerializeField] private AudioClip buttonAudioClip;

    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.SetActive(true);
        }
        errorCode.SetActive(false);
    }

    public void AddNumber(string number) // Calling this via buttons, to add a button to our code 
    {
        if (screen.text.Length <= codeLength -1 )
        {
            screen.text += number;
        }
        
        audioSource.PlayOneShot(buttonAudioClip);
    }

    public void Clear() // Erase all data
    {
        screen.text = "";
    }

    public void CheckCode() // Check if the code text is the same as our code word
    {
        if (screen.text == codeWord) // if yes load new scene
        {
            keypad.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            audioSource.PlayOneShot(errorAudioClip);
            StartCoroutine(ShowErrorCode());
        }
    }

    private IEnumerator ShowErrorCode() // With the wrong code:
    {
        foreach (var button in buttons) // We disable all buttons so the player can't click anything + enable error
        {
            button.SetActive(false);
        }

        screen.text = "";
        errorCode.SetActive(true);
        yield return new WaitForSeconds(3); // Wait 3 Seconds
        
        foreach (var button in buttons) // reenable everything + disable error
        {
            button.SetActive(true);
        }
        
        errorCode.SetActive(false);
    }
}

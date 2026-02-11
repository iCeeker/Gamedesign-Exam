using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitOnThomas : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] TextAsset textAsset;

    [SerializeField] private float waitTime;
    [SerializeField] private GameObject doorClosed; 
    [SerializeField] private GameObject doorOpen;

    private void Awake()
    {
        StartCoroutine(WaitForThomas());
    }
    
    private IEnumerator WaitForThomas()
    {
        yield return new WaitForSeconds(waitTime);
        
        Debug.Log("Works");
        
        doorClosed.SetActive(false);
        doorOpen.SetActive(true);
        dialogueManager.StartDialogue(textAsset);
    }
 }

using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestMain : MonoBehaviour
{
    private CollectionTracker collectionTracker;
    
    [SerializeField] private string questDescription;
    public int currentQuestIndex;

    [SerializeField] private TextMeshProUGUI questDescriptionTMP;
    
    [SerializeField] List<SO_Quest> QuestTypesList;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

   

    public void SetActiveQuest() // Set the current active quest according to the questIndex
    {
        currentQuestIndex = QuestTypesList[currentQuestIndex].questNumber;
       
        questDescriptionTMP.text = QuestTypesList[currentQuestIndex].questDescription;
    }

    public void CompleteQuest() // Increase the current quest index and play a quest completed sound effect
    {
        QuestTypesList[currentQuestIndex].questObject.SetActive(false);
        QuestTypesList[currentQuestIndex + 1].questObject.SetActive(true);
        
        audioSource.clip = audioClip;
        audioSource.Play();
        
        currentQuestIndex++;
        
    }

    private void Update() // temp check, need to implement a way that it doesn't check ever frame if we complete a quest
    {
        SetActiveQuest();
    }
    
    // Need an "Next Object" from SO that activates 
}

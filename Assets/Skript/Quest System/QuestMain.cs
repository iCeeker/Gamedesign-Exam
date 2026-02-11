using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestMain : MonoBehaviour
{
    private CollectionTracker collectionTracker;
    
    [Header("Quest Details")]
    [SerializeField] private string questDescription;
    public int currentQuestIndex;
    
    [SerializeField] List<SO_Quest> QuestTypesList;

    [Header("Quest Description on UI")]
    [SerializeField] private TextMeshProUGUI questDescriptionTMP;
    
    [Header("Quest Objects/Locations")]
    [SerializeField] private List<GameObject> QuestGameObjects;
    [SerializeField] private int questGameObjectsCounter; // at start always stay at 0, we inc this by completing quests
    
    [Header("Quest Completion Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private bool questIsCompleted;

   

    public void SetActiveQuest() // Set the current active quest according to the questIndex
    {
        currentQuestIndex = QuestTypesList[currentQuestIndex].questNumber;
       
        questDescriptionTMP.text = QuestTypesList[currentQuestIndex].questDescription;
    }

    public void CompleteQuest() // Increase the current quest index and play a quest completed sound effect
    {
        if (QuestTypesList[currentQuestIndex].needsQuestObject && QuestTypesList[currentQuestIndex].questType != QuestType.Collection )
        {
            QuestGameObjects[questGameObjectsCounter].gameObject.SetActive(false);

            questGameObjectsCounter++;

            QuestGameObjects[questGameObjectsCounter].gameObject.SetActive(true);
            questIsCompleted = true;
        }
        else if (QuestTypesList[currentQuestIndex].needsQuestObject &&
                 QuestTypesList[currentQuestIndex].questType == QuestType.Collection)
        {
            QuestGameObjects[questGameObjectsCounter].gameObject.SetActive(false);

            questGameObjectsCounter++;

            QuestGameObjects[questGameObjectsCounter].gameObject.SetActive(true);
            questIsCompleted = true;
        }

        if (questIsCompleted)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        
            currentQuestIndex++;
        }
    }

    private void Update() // temp check, need to implement a way that it doesn't check every frame if we complete a quest
    {
        
        SetActiveQuest();
    }
    
}

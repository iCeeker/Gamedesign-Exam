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
   
    [SerializeField] private List<GameObject> interactionGameObjects; // todo: rework this!!!
    [SerializeField] private int currentInteractionGameObjectIndex; // current idea is to have a list everything in the scene to interact with. if we interact with the correct one for the quest, we complete the quest
    
    
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

   

    public void SetActiveQuest() // Set the current active quest according to the questIndex
    {
        currentQuestIndex = QuestTypesList[currentQuestIndex].questNumber;
       
        questDescriptionTMP.text = QuestTypesList[currentQuestIndex].questDescription;
    }

    public void CompleteQuest() // Increase the current quest index and play a quest completed sound effect
    {
        currentQuestIndex++;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void Update() // temp check, need to implement a way that it doesn't check ever frame if we complete a quest
    {
        SetActiveQuest();
    }

    public void UpdateQuestStatus() // Depending on the type of quest 
    {
        if (QuestTypesList[currentQuestIndex].questType == QuestType.Collection && collectionTracker.meetsRequirements && QuestTypesList[currentQuestIndex].questGameObject == interactionGameObjects[currentInteractionGameObjectIndex])
        {
            CompleteQuest(); // if we meet the requirements and talk to the npc, we complete the quest
        }
        else
        {
            collectionTracker.meetsRequirements = false; // create npc dialogue that says that we still need stuff
        }

        if (QuestTypesList[currentQuestIndex].questType == QuestType.Interaction && QuestTypesList[currentQuestIndex].questGameObject == interactionGameObjects[currentInteractionGameObjectIndex])
        {
            CompleteQuest(); 
        }

        if (QuestTypesList[currentQuestIndex].questType == QuestType.Reach && QuestTypesList[currentQuestIndex].questGameObject == interactionGameObjects[currentInteractionGameObjectIndex])
        {
            // Check if player has entered an area
        }
    }
}

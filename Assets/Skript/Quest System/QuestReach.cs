using System;
using TMPro;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class QuestReach : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private QuestMain questMain;
    [SerializeField] private SO_Quest quest;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && questMain.currentQuestIndex == quest.questNumber) // create  new lists with NPC's, Items & Reach zones. Populate those with each with EVERYTHING we want to interact with
                                                                                            // create an int that ++ if you interact with the object 
        {
            questMain.CompleteQuest();
            Destroy(gameObject);
        }
    }
}

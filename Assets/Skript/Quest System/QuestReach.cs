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
        if (other.CompareTag("Player"))
                                                                                           
        {
            questMain.CompleteQuest(); 
            Destroy(gameObject);
        }
    }
}

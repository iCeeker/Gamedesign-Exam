using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    [SerializeField] private int requiredPlankAmount;
    [SerializeField] private int requiredNailAmount;
    [SerializeField] private int requiredHammerAmount;

    [SerializeField] private GameObject[] blockingGameObjects;
    [SerializeField] private GameObject barrierGameObject;
    [SerializeField] private GameObject bridge;
    [SerializeField] private QuestMain questMain;
    
    public bool meetsRequirements;
    
    public int plankAmount;
    public int nailAmount;
    public int hammerAmount;

    public void CheckRequirements()
    {
        if (plankAmount <= requiredPlankAmount)
        {
            meetsRequirements = false;
            // Give Player Info that you need more Planks
        }

        if (nailAmount <= requiredNailAmount)
        {
            meetsRequirements = false;
            // Give Player Info that you need more Nails
        }

        if (hammerAmount <= requiredHammerAmount)
        {
            meetsRequirements = false;
            // Give Player Info that you need more Hammers
        }

        if (plankAmount >= requiredPlankAmount && nailAmount >= requiredNailAmount &&
            hammerAmount >= requiredHammerAmount)
        {
            Debug.Log("Found all items");
            meetsRequirements = true;

            foreach (var blockingObjects in blockingGameObjects)
            {
                blockingObjects.gameObject.SetActive(false);
            }
            
            bridge.SetActive(true);
            barrierGameObject.SetActive(false);
            questMain.CompleteQuest();
            // Todo: Switch this to an npc 
        }
    }
}

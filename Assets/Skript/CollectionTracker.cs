using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    public int plankAmount;
    public int nailAmount;
    public int hammerAmount;

    [SerializeField] private int requiredPlankAmount;
    [SerializeField] private int requiredNailAmount;
    [SerializeField] private int requiredHammerAmount;

    [SerializeField] private GameObject barrierGameObject;

    private CollectableInteraction collectableInteraction;
    [SerializeField] List<GameObject> collectables;
/*
    private void Awake()
    {
        collectableInteraction = collectables.GetComponent<CollectableInteraction>();
    }

    public void IncreaseItemAmount()
    {
        if (collectables.type == Type.Plank)
        {
            plankAmount =+ collectables.amount;
            // return feedback via txt that you found a plank
        }

        if (collectables.type == Type.Hammer)
        {
            hammerAmount =+ collectables.amount;
            // return feedback via txt that you found a hammer
        }

        if (collectables.type == Type.Nail)
        {
            nailAmount =+ collectables.amount;
           // return feedback via txt that you found a nail
        }
    }

    public void CheckRequirements()
    {
        if (plankAmount <= requiredPlankAmount)
        {
            // Give Player Info that you need more Planks
        }

        if (nailAmount <= requiredNailAmount)
        {
            // Give Player Info that you need more Nails
        }

        if (hammerAmount <= requiredHammerAmount)
        {
            // Give Player Info that you need more Hammers
        }

        if (plankAmount >= requiredPlankAmount && nailAmount >= requiredNailAmount &&
            hammerAmount >= requiredHammerAmount)
        {
            barrierGameObject.SetActive(false);
        }
    }

    /* Create Different Ints
     * function that increases the amount collected ++
     * return feedback message
     */


}

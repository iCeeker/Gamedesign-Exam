using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    [SerializeField] private int requiredPlankAmount;
    [SerializeField] private int requiredNailAmount;
    [SerializeField] private int requiredHammerAmount;

    [SerializeField] private GameObject barrierGameObject;
    
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
            meetsRequirements = true;
            barrierGameObject.SetActive(false);
        }
    }

    /* Create Different Ints
     * function that increases the amount collected ++
     * return feedback message
     */


}

using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTracker : MonoBehaviour
{
    [SerializeField] private int requiredPlankAmount;
    [SerializeField] private int requiredNailAmount;
    [SerializeField] private int requiredHammerAmount;

    [SerializeField] private GameObject barrierGameObject;
    
    public int plankAmount;
    public int nailAmount;
    public int hammerAmount;

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

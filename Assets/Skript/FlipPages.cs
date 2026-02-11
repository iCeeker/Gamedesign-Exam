using System;
using UnityEngine;

public class FlipPages : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private int currentIndex;
    
    private void Awake()
    {
        pages[currentIndex].SetActive(true);
    }

    public void NextPage()
    {
        if (currentIndex < pages.Length -1 )
        {
            pages[currentIndex].SetActive(false);
            currentIndex++;
            pages[currentIndex].SetActive(true);
        }
    } 

    public void PreviousPage()
    {
        if (currentIndex >= 0)
        {
            pages[currentIndex].SetActive(false);
            currentIndex--;
            pages[currentIndex].SetActive(true);   
        }
    }
    
}

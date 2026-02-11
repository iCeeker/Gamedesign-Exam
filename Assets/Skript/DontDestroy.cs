using System;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource.PlayOneShot(audioClip);
    }
}

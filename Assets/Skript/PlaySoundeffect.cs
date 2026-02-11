using UnityEngine;

public class PlaySoundeffect : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.PlayOneShot(audioClip);
    }
}

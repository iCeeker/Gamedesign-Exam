using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TextAsset textAsset;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    [SerializeField] private string sceneName;
    [SerializeField] private int waitTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource.PlayOneShot(audioClip);
        dialogueManager.StartDialogue(textAsset);

        StartCoroutine(WaitForText());
    }

    private IEnumerator WaitForText()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);

    }
    
}

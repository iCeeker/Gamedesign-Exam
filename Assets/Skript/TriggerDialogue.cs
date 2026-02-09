using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private CheckState checkState;
    
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool hasAnimation;
    [SerializeField] private int animDuraton;
    [SerializeField] private string animTrigger;
    [SerializeField] private string workAroundTrigger;
    [SerializeField] private bool needsWorkaroundTrigger;
    
    [Header("Scene Management")]
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.GetInstance().StartDialogue(textAsset);
        }
    }

    private void Update()
    { 
        if (dialogueManager.dialogueIsPlaying )
        {
            return;
        } 
        if (!dialogueManager.dialogueIsPlaying && hasAnimation && animator != null) 
        {
            checkState.ActivateAnimationMap();
            StartCoroutine(DialogueToAnim());
        }
    }

    private IEnumerator DialogueToAnim()
    {
        if (needsWorkaroundTrigger)
        {
            animator.SetTrigger(workAroundTrigger);
        }
        animator.SetTrigger(animTrigger);
        yield return new WaitForSeconds(animDuraton);
        gameObject.SetActive(false);
        checkState.ActivatePlayerMap();
    }
    
    private IEnumerator AnimToDialogue()
    {
        if (needsWorkaroundTrigger)
        {
            animator.SetTrigger(workAroundTrigger);
        }
        animator.SetTrigger(animTrigger);
        yield return new WaitForSeconds(animDuraton);
        checkState.ActivatePlayerMap();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcMainLogic : MonoBehaviour, IInteraction
{
    [Header("Other Scripts")] [SerializeField]
    private TextAsset textAsset;

    [SerializeField] private DialogueManager dialogueManager;

    [Header("Patrol Logic")] [SerializeField]
    private Vector2[] patrolPoints;

    [SerializeField] private Vector2 target;
    [SerializeField] private float speed;
    [SerializeField] private float pauseTime;
    [SerializeField] private bool doesPatrol;
    [SerializeField] private bool walksHorizontally;
    [SerializeField] private bool walksVertically;
    public bool activeDialogue;
    
    public bool isPaused;
    private int patrolIndex;
    private Rigidbody2D rb;
    private Animator animator;

    private bool hasBeenInteracted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(MoveToNextControllpoint());
    }

    // Update is called once per frame
    void Update()
    {
        DialoguePlaying();
        PatrolL();
    }

    IEnumerator MoveToNextControllpoint()
    {
        isPaused = true;
        animator.Play("Idle_Down");

        yield return new WaitForSeconds(pauseTime);

        if (patrolPoints.Length != 0)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            target = patrolPoints[patrolIndex];
            isPaused = false;

            if (walksHorizontally)
            {
                animator.Play("Move_Right");
            }

            if (walksVertically)
            {
                animator.Play("Move_Up");
            }
        }
    }

    private void PatrolL()
    {
        if (!dialogueManager.dialogueIsPlaying && doesPatrol && !activeDialogue)
        {
            if (isPaused)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 direction = ((Vector3)target - transform.position).normalized;

            if (direction.x < 0 && transform.localScale.x > 0 ||
                direction.x > 0 && transform.localScale.x < 0 && walksHorizontally)
            {
                animator.Play("Move_Left");
            }

            if (direction.y < 0 && transform.localScale.y > 0 ||
                direction.y > 0 && transform.localScale.y < 0 && walksVertically)
            {
                animator.Play("Move_Down");
            }


            rb.linearVelocity = direction * speed;

            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                StartCoroutine(MoveToNextControllpoint());
            }
        }
    }

    private void DialoguePlaying()
    {
        if (dialogueManager.dialogueIsPlaying)
        {
            activeDialogue = true;
            isPaused = true;
            rb.linearVelocity = Vector2.zero;
            animator.Play("Idle_Down");
        }

        if (!dialogueManager.dialogueIsPlaying)
        {
            activeDialogue = false;
        }
    }

    public void Interact()
    {
        Debug.Log("We Interacted");
        DialogueManager.GetInstance().StartDialogue(textAsset);
    }

    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
}
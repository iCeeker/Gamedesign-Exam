using UnityEngine;
using System.Collections;

public class NPC_Patrol : MonoBehaviour
{
    [SerializeField] private Vector2[] patrolPoints;
    [SerializeField] private Vector2 target;
    [SerializeField] private float speed;
    [SerializeField] private float pauseTime;

    private bool isPaused;
    private int patrolIndex;
    private Rigidbody2D rb;
    
    private Animator animator;
    
    
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
        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        if (direction.x < 0 && transform.localScale.x > 0 || direction.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(MoveToNextControllpoint());
        }
    }

    IEnumerator MoveToNextControllpoint()
    {
        isPaused = true;
        animator.Play("Idle_Down");
        
        yield return new WaitForSeconds(pauseTime);
        
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[patrolIndex];
        isPaused = false;
        
        animator.Play("Move_Right");
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_4D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private Vector2 inputDirection;
    
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private string direction = "Down";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    //    animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animations();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void Animations()
    {
        if (animator == null)
        {
            return;
        }
        
        string animationName = "";

        if (moveInput == Vector2.zero)
        {
            animationName = "Idle_";
        }
        else
        {
            animationName = "Move_";
        }
        
        animator.Play(animationName + direction);
        
    }

    private Vector3 GetDirection(Vector3 input)
    {
        Vector3 trueDirection = Vector3.zero;
        if (input.y > 0.01f)
        {
            direction = "Up";
            trueDirection = new Vector2(0, 1);
        }
        else if (input.y < -0.01f)
        {
            direction = "Down";
            trueDirection = new Vector2(0, -1);
        }
        else if (input.x > 0.01f)
        {
            direction = "Right";
            trueDirection = new Vector2(1, 0);
        }
        else if (input.x < -0.01f)
        {
            direction = "Left";
            trueDirection = new Vector2(-1, 0);
        }
        else
        {
            trueDirection = Vector2.zero;
        }
        return trueDirection;
    }
    
    private void OnMove(InputValue value)
    {
        inputDirection = value.Get<Vector2>().normalized;
        moveInput = GetDirection(inputDirection);
    }
    
    
}

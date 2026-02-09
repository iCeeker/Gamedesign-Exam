using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_8D : MonoBehaviour
{
    [SerializeField] private Animator animator;
   // [SerializeField] private CinemachineCamera cinemachineCamera; ToDo: on Start set this to follow player to avoid stuttering
    private Rigidbody2D rb; 
    private Vector2 moveInput;
    
    
   [SerializeField] private float moveSpeed = 5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isMoving", true);

        if (context.canceled)
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("lastDirectionX", moveInput.x);
            animator.SetFloat("lastDirectionY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("directionX", moveInput.x);
        animator.SetFloat("directionY", moveInput.y);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private bool submitPressed = false;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one InputManager in the scene");
        }
        instance = this;
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    
    public void SubmitPressed(InputAction.CallbackContext context) // checking if we're pressing the space button
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    public bool SubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
    
    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }
    
   
}

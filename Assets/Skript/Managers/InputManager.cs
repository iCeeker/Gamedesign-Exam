using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private bool submitPressed = false;
    private bool repeatedInput = false;

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

    public void RepeatedInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            repeatedInput = true;
        }
        else if (context.canceled)
        {
            repeatedInput = false;
        }
    }

    public bool RepeatedInput()
    {
        bool result = repeatedInput;
        repeatedInput = false;
        return result;
    }
    
    public void RegisterRepeatedInput()
    {
        repeatedInput = false;
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

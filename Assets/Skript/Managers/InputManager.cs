using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CheckState checkState;
    
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

    public void CloseInteraction(InputAction.CallbackContext context)
    {
        GameObject[] items;
        items = GameObject.FindGameObjectsWithTag("Interaction");
        Debug.Log(items.Length);

        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        checkState.ActivatePlayerMap();
    }

}

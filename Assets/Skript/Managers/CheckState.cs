using UnityEngine;
using UnityEngine.InputSystem;

public class CheckState : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInput;

    public void DisablePlayerInput() // Maybe unify them into TogglePlayerInput and check if active == true, disable & viceversa
    {
        Debug.Log("DisablePlayerInput");
        playerInput.Disable();
    }

    public void EnablePlayerInput()
    {
        Debug.Log("EnablePlayerInput");
        Debug.Log(playerInput.name);
        playerInput.Enable();
    }
}

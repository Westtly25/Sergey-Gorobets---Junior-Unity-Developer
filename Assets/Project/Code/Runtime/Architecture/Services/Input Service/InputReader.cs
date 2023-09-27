using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader
{
    private PlayerInput inputActions;

    public InputReader() =>
        inputActions = new PlayerInput();

    public void EnableInput() =>
        inputActions.Enable();

    public void DisableInput() =>
        inputActions.Disable();

    public void SetEnableGameplayInput(bool isEnable)
    {
        inputActions.GameplayActionMap.Enable();
        inputActions.GameplayActionMap.Disable();
    }
}
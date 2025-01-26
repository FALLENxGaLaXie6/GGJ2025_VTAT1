using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    
    private InputActions inputActions;

    public event EventHandler OnPauseAction;

    private void Awake()
    {
        Instance = this;
        
        inputActions = new InputActions();
        inputActions.Faucet.Enable();

        inputActions.Faucet.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
}

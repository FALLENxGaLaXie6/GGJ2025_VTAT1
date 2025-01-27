using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameOver;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void GameOver(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            inputActions.GameOver.Enable();
            inputActions.GameOver.MainMenu.performed += Exit_performed;
        }
    }

    private void Exit_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Loader.Load(Loader.Scene.MainMenuScene);
        Time.timeScale = 1f;
    }
}

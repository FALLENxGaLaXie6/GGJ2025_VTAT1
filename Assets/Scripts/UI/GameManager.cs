using UnityEngine;
using UnityEngine.UI;
using System;
using UI;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Button unpauseButton;
    [SerializeField] private int goalDrinks = 0;
    public static GameManager Instance { get; private set; }
    
    private bool isGamePaused = false;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    public event EventHandler OnStateChanged;

    private enum State
    {
        Running,
        GameOver
    }

    private State state;

    private void Awake()
    {
        Instance = this;
        state = State.Running;
        
        unpauseButton.onClick.AddListener(UnpauseClick);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Running:
                if (GameScoreUI.Instance.GetSuccessfulScore() >= goalDrinks)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }

                break;
        }
    }

    private void UnpauseClick()
    {
        TogglePauseGame();
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
}

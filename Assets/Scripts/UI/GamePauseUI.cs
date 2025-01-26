using UnityEngine;
using UnityEngine.UI;
using System;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private AudioSource pauseSong;
    [SerializeField] private AudioSource gameSong;
    
    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        Hide();
        pauseSong.mute = true;
        gameSong.mute = false;
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
        pauseSong.mute = false;
        gameSong.mute = true;
    }
    
    
    private void GameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
        pauseSong.mute = true;
        gameSong.mute = false;
    }
    
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

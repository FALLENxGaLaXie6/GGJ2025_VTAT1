using TMPro;
using UnityEngine;
using System;
using UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI drinksServedText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
            drinksServedText.text = GameScoreUI.Instance.GetSuccessfulScore().ToString();
            Time.timeScale = 0f;
        }
        else
        {
            Hide();
        }
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

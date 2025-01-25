using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayClick);
        quitButton.onClick.AddListener(QuitClick);
    }

    private void PlayClick()
    {
        Loader.Load(Loader.Scene.GameScene);
    }

    private void QuitClick()
    {
        Application.Quit();
    }
}

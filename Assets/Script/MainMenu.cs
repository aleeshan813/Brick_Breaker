using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button _playButton;
    public Button _optionButton;
    public Button _quitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(PlayGame);
        _quitButton.onClick.AddListener(QuintGame);
    }
    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(PlayGame);
        _quitButton.onClick.RemoveListener(QuintGame);
    }

    public void PlayGame()
    {
        GameManager.Instance.NewGame();
    }
    public void QuintGame()
    {
        Application.Quit();
    }
}
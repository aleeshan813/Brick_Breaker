using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public GameObject WinPanel;

    public Button _next, _restart, _menu;

    private void Awake()
    {
        _next.onClick.AddListener(GameManager.Instance.GameOverr);
        _restart.onClick.AddListener(GameManager.Instance.GameOverr);
        _menu.onClick.AddListener(Menu);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameWin += Pause;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameWin -= Pause;
    }
    public void Continue()
    {
        WinPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

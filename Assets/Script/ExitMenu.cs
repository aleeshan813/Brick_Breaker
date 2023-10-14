using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameObject ExitPanel;

    public Button  _restart, _menu;

    private void Awake()
    {
        _restart.onClick.AddListener(GameManager.Instance.GameOverr);
        _menu.onClick.AddListener(Menu);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += Pause;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= Pause;
    }

    public void Pause()
    {
        ExitPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

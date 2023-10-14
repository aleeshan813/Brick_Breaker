using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public Button _continue, _restart, _menu;

    private void Awake()
    {
        _continue.onClick.AddListener(Continue);
        _restart.onClick.AddListener(Restart);
        _menu.onClick.AddListener(Menu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
            GameManager.Instance.RestartLevel();
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    
}

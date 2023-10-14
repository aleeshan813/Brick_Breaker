using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
   

    public static GameManager Instance;

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    public AudioSource hitsoundeffect;
    public AudioSource lifesoundeffect;
    public AudioSource gameover;
    public AudioSource gamewin;

   /* public List<AudioSource> audioSources;


    void OnMouseDown()
    {
        foreach (AudioSource audioSorce in audioSources)
        {
            audioSorce.Stop();
        }
    }
*/

    public int level = 0;
    public int score = 0;
    public int life = 3;
    int point = 1;
    

    public float Currenttime = 60f;
    public bool countdown;
    public bool hasLimit;
    public float timeLimit = 0f;

    public Action OnGameOver;
    public Action OnGameWin;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
        GameManager.Instance = this;
    }

    public void NewGame()
    {
        score = 0;
        life = 3;
        Currenttime = 60f;
        Time.timeScale = 1f;    
        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
    }
    public void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();  
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Hit()
    {
        if (this.score >= 9)
        {
            GameWin();
        }
        hitsoundeffect.Play();
        this.score += point;
    }

    public void GameOverr()
    {
        NewGame();
    }

    public void Miss()
    {
        this.life--;
        if (this.life > 0)
        {
            ResetLevel();
            lifesoundeffect.Play();
        }
        else
        {
            GameOver();
        }
    }
    
    public void Playertime()
    {
        this.Currenttime = this.countdown ? this.Currenttime -= Time.deltaTime : this.Currenttime += Time.deltaTime;
        if(this.hasLimit && ((this.countdown && this.Currenttime <= this.timeLimit) || (!this.countdown && this.Currenttime >= this.timeLimit)))
        {
            this.Currenttime = this.timeLimit;
            enabled = false;

        }   
    }
    public void GameWin()
    {
        if(OnGameWin != null)
        {
            OnGameWin.Invoke();
        }    
        gamewin.Play();
    }

    public void GameOver()
    {
        if(OnGameOver != null) OnGameOver.Invoke();
        gameover.Play();
       /* OnMouseDown();*/
    }
}

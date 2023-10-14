using UnityEngine;
using TMPro;


public class STLAssigner : MonoBehaviour
{
    [SerializeField] TMP_Text time, score, life;

    GameManager GManager;

    private void Start()
    {
        GManager = GameManager.Instance;
    }

    private void Update()
    {
        float minutes = Mathf.FloorToInt(GManager.Currenttime / 60);
        float seconds = Mathf.FloorToInt(GManager.Currenttime % 60);
        time.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        score.text = "Score: " + GManager.score.ToString();
        life.text = "Life: " + GManager.life.ToString();

        if (GManager.Currenttime <= 0 && Time.timeScale > 0)
        {
            time.color = Color.red;
            GManager.GameOver();
        } 
    }
}

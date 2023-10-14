using UnityEngine;

public class Brick : MonoBehaviour
{
    
    public SpriteRenderer SpriteRenderer { get; private set; }
    public int health {  get; private set; }
    public Sprite[] states;
    public bool Unbrickable;
    private void Awake()
    {
        this.SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        ResetBrick();
    }
    public void ResetBrick()
    {
        this.gameObject.SetActive(true);
        if (!this.Unbrickable)
        {
            this.health = this.states.Length;
            this.SpriteRenderer.sprite = this.states[this.health - 1];
        }
    }
    void Hit()
    {
        if (this.Unbrickable)
        {
            return;
        }
        this.health--;
        
        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.SpriteRenderer.sprite = this.states[this.health - 1];
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") 
        {
            Hit();
            GameManager.Instance.Hit();
        }
    }
}

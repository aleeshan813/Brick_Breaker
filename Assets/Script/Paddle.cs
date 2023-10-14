using UnityEngine;
using UnityEngine.Rendering;

public class Paddle : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float MaxBounceAngle = 75f;

    void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ResetPaddle()
    {
        this.transform.position =new Vector2(0f,this.transform.position.y);
        this.rigidbody.velocity = Vector2.zero;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }

        else
        {
            this.direction = Vector2.zero;
        }

    }
    void FixedUpdate()
    {
        if(this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();  

        if (ball != null)
        {
            Vector3 PaddlePosition = this.transform.position;
            Vector2 ContactPoint = collision.GetContact(0).point;

            float offset = PaddlePosition.x - ContactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float CurrectAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float BounceAngle = (offset / width) * this.MaxBounceAngle;
            float NewAngle = Mathf.Clamp(CurrectAngle + BounceAngle, -this.MaxBounceAngle, this.MaxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(NewAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

        }
    }

}

using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;

    public float UpperBound;
    public float LowerBound;

    public float FlapVelocity = 20;

    private bool isFlapping = false;

    public UnityEvent PlayerDied = new();
    public UnityEvent<int> ScoreIncreased = new();

    void FixedUpdate()
    {
        if (isFlapping)
        {
            player.velocity = new Vector2(player.velocity.x, FlapVelocity);
            isFlapping = false;
        }

        DetectOutOfBounds();
    }

    public void Flap()
    {
        isFlapping = true;
    }

    private void DetectOutOfBounds()
    {
        var yPosition = player.position.y;

        if (yPosition > UpperBound)
        {
            player.position = new Vector2(player.position.x, Mathf.Min(UpperBound, player.position.y));

            Debug.Log("Player is out of Upper bound");

            PlayerDied.Invoke();
        } else if (yPosition < LowerBound)
        {
            player.position = new Vector2(player.position.x, Mathf.Max(LowerBound, player.position.y));

            Debug.Log("Player is out of LowerBound bound");

            PlayerDied.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colliding with Pipe
        if (collision.gameObject.layer == 6)
        {
            PlayerDied.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            ScoreIncreased.Invoke(1);
        }
    }
}

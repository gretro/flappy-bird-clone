using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;

    public float UpperBound;
    public float LowerBound;

    public float FlapVelocity = 20;

    private bool isFlapping = false;

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
            // player.velocity = new Vector2(player.velocity.x, Mathf.Min(0));

            Debug.Log("Player is out of Upper bound");

            // TODO: Raise event
        } else if (yPosition < LowerBound)
        {
            player.position = new Vector2(player.position.x, Mathf.Max(LowerBound, player.position.y));
            // player.velocity = new Vector2(player.velocity.x, 0);

            Debug.Log("Player is out of LowerBound bound");

            // TODO: Raise event
        }
    }
}

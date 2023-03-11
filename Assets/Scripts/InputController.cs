using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Flap();
        }
    }
}

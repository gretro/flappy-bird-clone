using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public PlayerController player;
    public float LowerBound = -7.5f;
    public float UpperBound = 7.5f;
    public float FlapRate = 0.5f;


    private bool flap = false;
    private float elapsed = 0;

    private void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    void Update()
    {
        if (flap)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= FlapRate)
            {
                player.Flap();
                elapsed = 0;
            }

        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void FixedUpdate()
    {
        if (!flap && player.transform.position.y < LowerBound)
        {
            flap = true;
            player.Flap();
        }

        if (flap && player.transform.position.y >= UpperBound)
        {
            flap = false;
        }
    }
}

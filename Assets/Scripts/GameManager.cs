using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public PipeSpawner pipeSpawner;

    public GameObject GameOverScreen;
    public TextMeshProUGUI StartCounterText;
    public TextMeshProUGUI ScoreText;

    private float elapsed = 0;
    private int startCounter = 3;

    private bool gameStarted = false;
    private bool isGameOver = false;
    private int score = 0;

    private void Update()
    {
        if (!gameStarted)
        {
            elapsed += Time.deltaTime;

            if (elapsed >= 0.75)
            {
                DecreaseCounter();
                elapsed = 0;
            }
        }

    }

    private void Start()
    {
        GameOverScreen.SetActive(false);
        player.SetEnabled(false);
        pipeSpawner.enabled = false;
        StartCounterText.enabled = true;
    }

    private void StartGame()
    {
        player.SetEnabled(true);
        pipeSpawner.enabled = true;
        StartCounterText.enabled = false;
        gameStarted = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;

        player.enabled = false;
        GameOverScreen.SetActive(true);
    }

    public void IncreaseScore(int points)
    {
        if (isGameOver)
        {
            return;
        }

        score += points;

        ScoreText.text = score.ToString();
    }

    private void DecreaseCounter()
    {
        startCounter--;

        var text = startCounter > 0 ? startCounter.ToString() : "Flap!";

        StartCounterText.text = text;
        if (startCounter == -1)
        {
            StartGame();
        }
    }
}

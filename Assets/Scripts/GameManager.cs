using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public GameObject GameOverScreen;
    public TextMeshProUGUI ScoreText;

    private bool isGameOver = false;
    private int score = 0;

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
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public GameObject TitleScreen;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        player.enabled = false;
        TitleScreen.SetActive(true);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        AudioController.Instance.gameMusic.Stop();
        AudioController.Instance.Play(AudioController.Instance.gameOver);
        HUDController.Instance.gameOverPanel.SetActive(true);
        HUDController.Instance.estadosJugador.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        AudioController.Instance.gameMusic.Stop();
        AudioController.Instance.Play(AudioController.Instance.win);
        HUDController.Instance.winPanel.SetActive(true);
        HUDController.Instance.estadosJugador.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        AudioController.Instance.Play(AudioController.Instance.button);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void VolverAlMenu()
    {
        AudioController.Instance.Play(AudioController.Instance.button);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
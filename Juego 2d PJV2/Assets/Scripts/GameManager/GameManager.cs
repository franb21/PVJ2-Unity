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
        HUDController.Instance.gameOverPanel.SetActive(true);
        HUDController.Instance.estadosJugador.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        HUDController.Instance.winPanel.SetActive(true);
        HUDController.Instance.estadosJugador.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string menuLabel;
    [SerializeField] private string gameLabel;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Texture2D aimArrow;
    [SerializeField] private GameObject pausePanel;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameOver.SetActive(false);
        Cursor.SetCursor(aimArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameLabel);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuLabel);
    }

    public void SetGameOver()
    {
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
        gameOver.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string menuLabel;
    [SerializeField] private string gameLabel;
    [SerializeField] private GameObject gameOver;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameOver.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameLabel);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menuLabel);
    }

    public void SetGameOver()
    {
        player.gameObject.SetActive(false);
        gameOver.SetActive(true);
    }
}
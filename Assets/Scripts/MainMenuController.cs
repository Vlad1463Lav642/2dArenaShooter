using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string gameLabel;
    [SerializeField] private GameObject characterPanel;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayerSelector()
    {
        characterPanel.SetActive(true);
    }

    public void StartGame(int id)
    {
        PlayerPrefs.SetInt("CharacterID", id);
        SceneManager.LoadScene(gameLabel);
    }
}
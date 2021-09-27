using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string gameLabel;
    [SerializeField] private GameObject characterPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private Text[] nameLabels;
    [SerializeField] private GameObject[] characters;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayerSelector()
    {
        characterPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameLabel);
    }

    public void AboutInfo(int id)
    {
        PlayerPrefs.SetInt("CharacterID", id);
        PlayerController playerCharacter = characters[id].GetComponent<PlayerController>();
        ShootController shootCharacter = characters[id].GetComponent<ShootController>();

        aboutPanel.GetComponent<AboutInfoController>().ChooseCharacter(nameLabels[id].text, playerCharacter.GetMaxHealth(), shootCharacter.GetBulletForce(), shootCharacter.GetDamage());
        aboutPanel.SetActive(true);
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }
}
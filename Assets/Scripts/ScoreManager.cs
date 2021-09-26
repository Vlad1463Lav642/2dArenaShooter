using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scorePanel;
    [SerializeField] private Text highScoreLabel;
    private float scoreCount;
    private float highScoreStorage;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreStorage = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0f);
        }
        highScoreLabel.text = $"Total Score: {highScoreStorage}";
    }

    public void AddScore(float score)
    {
        scoreCount += score;
        scorePanel.text = $"Score: {score}";

        if(scoreCount > highScoreStorage)
        {
            highScoreStorage = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreStorage);
            highScoreLabel.text = $"Total Score: {highScoreStorage}";
        }
    }
}
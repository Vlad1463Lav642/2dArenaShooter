using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] playerCharacters;
    [SerializeField] private GameObject[] enemyCharacters;

    [SerializeField] private float enemySpawnTime;
    private float enemySpawnTimeCount;
    private int playerSelectedCharacter;

    private void Start()
    {
        playerSelectedCharacter = PlayerPrefs.GetInt("ID");

        int playerPosition = (int)Random.Range(0f, spawnPoints.Length);
        Instantiate(playerCharacters[playerSelectedCharacter],spawnPoints[playerPosition].position,spawnPoints[playerPosition].rotation);

        enemySpawnTimeCount = enemySpawnTime;
    }

    private void Update()
    {
        if(enemySpawnTimeCount > 0)
        {
            enemySpawnTimeCount -= Time.deltaTime;
        }
        else
        {
            int enemyPosition = (int)Random.Range(0f, spawnPoints.Length);
            int enemySelector = (int)Random.Range(0f, enemyCharacters.Length);

            Instantiate(enemyCharacters[enemySelector], spawnPoints[enemyPosition].position, spawnPoints[enemyPosition].rotation);
            enemySpawnTimeCount = enemySpawnTime;
        }
    }
}
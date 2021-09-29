using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform[] characterSpawnPoints;
    [SerializeField] private Transform[] healthSpawnPoints;
    [SerializeField] private GameObject[] playerCharacters;
    [SerializeField] private GameObject[] enemyCharacters;
    [SerializeField] private GameObject healthObject;
    [SerializeField] private AudioSource spawnAudio;
    [SerializeField] private float enemySpawnTime;
    [SerializeField] private float healthSpawnTime;

    private float enemySpawnTimeCount;
    private float healthSpawnTimeCount;
    private int playerSelectedCharacter;

    private void Start()
    {
        playerSelectedCharacter = PlayerPrefs.GetInt("CharacterID");

        int playerPosition = (int)Random.Range(0f, characterSpawnPoints.Length);

        spawnAudio.Play();

        Instantiate(playerCharacters[playerSelectedCharacter],characterSpawnPoints[playerPosition].position,characterSpawnPoints[playerPosition].rotation);

        enemySpawnTimeCount = enemySpawnTime;
        healthSpawnTimeCount = healthSpawnTime;
    }

    private void Update()
    {
        if(enemySpawnTimeCount > 0)
        {
            enemySpawnTimeCount -= Time.deltaTime;
        }
        else
        {
            SpawnEnemyCharacter();
        }

        if(healthSpawnTimeCount > 0)
        {
            healthSpawnTimeCount -= Time.deltaTime;
        }
        else
        {
            SpawnPickup();
        }
    }

    private void SpawnEnemyCharacter()
    {
        int enemyPosition = (int)Random.Range(0f, characterSpawnPoints.Length);
        int enemySelector = (int)Random.Range(0f, enemyCharacters.Length);

        if (characterSpawnPoints[enemyPosition].GetComponent<SpawnPointScript>().GetIsStayed() == false)
        {
            spawnAudio.Play();

            Instantiate(enemyCharacters[enemySelector], characterSpawnPoints[enemyPosition].position, characterSpawnPoints[enemyPosition].rotation);
            enemySpawnTimeCount = enemySpawnTime;
        }
        else
        {
            SpawnEnemyCharacter();
        }
    }

    private void SpawnPickup()
    {
        int healthPosition = (int)Random.Range(0f, healthSpawnPoints.Length);

        if (healthSpawnPoints[healthPosition].GetComponent<SpawnPointScript>().GetIsStayed() == false)
        {
            spawnAudio.Play();

            Instantiate(healthObject, healthSpawnPoints[healthPosition].position, healthSpawnPoints[healthPosition].rotation);
            healthSpawnTimeCount = healthSpawnTime;
        }
        else
        {
            SpawnPickup();
        }
    }
}
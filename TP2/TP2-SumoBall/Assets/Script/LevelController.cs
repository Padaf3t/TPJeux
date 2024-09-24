using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyRemaining;
    public GameObject[] powerUps;
    public GameObject enemyPrefab;
    private int difficultyLvl = 0;
    private float bound = 10f;

    public bool gameOver = false;
    public static LevelController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NextLevel();
    }

    private void Update()
    {
        if(enemyRemaining == 0)
        {
            NextLevel();
        }
    }

    public void EnemyOutOfBound()
    {
        enemyRemaining--;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    private void NextLevel()
    {
        UpDifficulty();
        SpawnEnemies();
        SpawnPowerUp();
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i < difficultyLvl; i++)
        {
            if (i % 10 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_CINQ);
            else if (i % 5 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_QUATRE);
            else if (i % 3 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_TROIS);
            else if (i % 2 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_DEUX);
            else InstantiateEnemy(EnemyController.EnemyLevel.LVL_UN);
        }
    }

    private void InstantiateEnemy(EnemyController.EnemyLevel level)
    {
        enemyRemaining++;

        Vector3 spawnPos = SetSpawnPos();

        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        enemyPrefab.GetComponent<EnemyController>().InitializeEnemy(level);
    }

    private void SpawnPowerUp()
    {
        Vector3 spawnPos = SetSpawnPos();
        GameObject powerUp = powerUps[(int)Random.Range(0f, powerUps.Length)];
        Instantiate(powerUp,spawnPos, transform.rotation);
    }

    private void UpDifficulty()
    {
        difficultyLvl++;
    }

    private Vector3 SetSpawnPos()
    {
        return new Vector3(Random.Range(-bound, bound), 2, Random.Range(-bound, bound));
    }
}

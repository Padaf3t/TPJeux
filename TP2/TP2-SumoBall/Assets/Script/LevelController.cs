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
    private float yPosEnemy = 2f;
    private float yPosPowerUp = 0f;

    private bool gameOver = false;
    public static LevelController instance;

    public AudioClip scream;
    public AudioSource source;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NextLevel();
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void EnemyOutOfBound()
    {
        enemyRemaining--;
        if (enemyRemaining == 0)
        {
            NextLevel();
        }
    }

    public void GameOver()
    {

        gameOver = true;
        source.PlayOneShot(scream);
    }

    private void NextLevel()
    {
        UpDifficulty();
        SpawnEnemies();
        SpawnPowerUp();
    }

    private void SpawnEnemies()
    {
        for(float i = 1; i <= difficultyLvl; i++)
        {
            if (i % 10 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_CINQ);
            else if (i % 7 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_QUATRE);
            else if (i % 5 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_TROIS);
            else if (i % 3 == 0) InstantiateEnemy(EnemyController.EnemyLevel.LVL_DEUX);
            else InstantiateEnemy(EnemyController.EnemyLevel.LVL_UN);
        }
    }

    private void InstantiateEnemy(EnemyController.EnemyLevel level)
    {
        enemyRemaining++;

        Vector3 spawnPos = SetSpawnPos(yPosEnemy);

        var ennemyObj = Instantiate(enemyPrefab, spawnPos, transform.rotation);
        ennemyObj.GetComponent<EnemyController>().InitializeEnemy(level);
    }

    private void SpawnPowerUp()
    {
        Vector3 spawnPos = SetSpawnPos(yPosPowerUp);
        GameObject powerUp = powerUps[(int)Random.Range(0f, powerUps.Length)];
        Instantiate(powerUp, spawnPos, transform.rotation);
    }

    private void UpDifficulty()
    {
        difficultyLvl++;
    }

    private Vector3 SetSpawnPos(float posY)
    {
        return new Vector3(Random.Range(-bound, bound), posY, Random.Range(-bound, bound));
    }
}

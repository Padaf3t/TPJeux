using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyRemaining;
    public GameObject[] powerUps;
    public GameObject enemyPrefab;
    private int difficultyLvl = 0;

    public enum EnemyLevel
    {
        LVL_UN = 1,
        LVL_DEUX = 2,
        LVL_TROIS = 3,
        LVL_QUATRE = 4,
        LVL_CINQ = 5
    }


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
            if (i % 10 == 0) InstanciateEnemy(EnemyLevel.LVL_CINQ);
            else if (i % 5 == 0) InstanciateEnemy(EnemyLevel.LVL_QUATRE);
            else if (i % 3 == 0) InstanciateEnemy(EnemyLevel.LVL_TROIS);
            else if (i % 2 == 0) InstanciateEnemy(EnemyLevel.LVL_DEUX);
            else InstanciateEnemy(EnemyLevel.LVL_UN);
        }
    }

    private void InstanciateEnemy(EnemyLevel level)
    {
        enemyRemaining++;
        Instantiate(enemyPrefab, new Vector3(0,0,1), transform.rotation);
        enemyPrefab.GetComponent<EnemyController>().InitializeEnemy(level);
    }

    private void SpawnPowerUp()
    {

    }

    private void UpDifficulty()
    {
        difficultyLvl++;
    }
}

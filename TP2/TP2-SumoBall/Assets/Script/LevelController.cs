using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyRemaining;
    public GameObject[] powerUps;
    public GameObject[] enemies;
    private int difficultyLvl = 0;


    public bool gameOver = false;
    public static LevelController instance;

    private void Awake()
    {
        instance = this;
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
            if (i % 10 == 0) InstanciateEnemy(5);
            if (i % 5 == 0) InstanciateEnemy(4);
            if (i % 3 == 0) InstanciateEnemy(3);
            if (i % 2 == 0) InstanciateEnemy(2);
            InstanciateEnemy(1);
        }
    }

    private void InstanciateEnemy(int enemyLvl)
    {
        enemyRemaining++;
        Instantiate(enemies[enemyLvl], transform.position, transform.rotation);
    }

    private void SpawnPowerUp()
    {

    }

    private void UpDifficulty()
    {
        difficultyLvl++;
    }
}

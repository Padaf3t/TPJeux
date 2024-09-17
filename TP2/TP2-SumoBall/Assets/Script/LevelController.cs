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
        SpawnEnemy();
        SpawnPowerUp();
    }

    private void SpawnEnemy()
    {
        
    }

    private void SpawnPowerUp()
    {

    }

    private void UpDifficulty()
    {
        difficultyLvl++;
    }
}

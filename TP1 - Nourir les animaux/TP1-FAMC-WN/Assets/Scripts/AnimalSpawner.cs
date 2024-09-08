using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    //reference
    public GameObject[] animals;
    private GameOverTrigger gameOverTrigger;
    private PlayerController playerController;
    //delay
    private float normalDelay = 2f;
    private float nextDelay;
    private float progress = 0f;
    //spawn
    private float xBoundaries;
    private Vector3 spawnPos;
    private float[] rotationDirectionTab = { -1, 1 };
    //difficulty
    private float timeBetweenDifficulty = 15.0f;
    private float difficultyProgress = 0.0f;
    
        
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();

        xBoundaries = playerController.GetMaxDistanceFromZero()-1;

        nextDelay = Random.Range(0.50f * normalDelay, 1.5f * normalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverTrigger.GetIsGameOver())
        {
            UpdateTimer();

            if (progress >= nextDelay)
            {
                progress = 0f;
                SpawnObstacle();

                nextDelay = Random.Range(0.50f * normalDelay, 1.5f * normalDelay);
            }

            if (difficultyProgress >= timeBetweenDifficulty)
            {
                difficultyProgress = 0f;
                normalDelay *= 0.95f;
            }
        }
    }

    private void UpdateTimer()
    {
        progress += Time.deltaTime;
        difficultyProgress += Time.deltaTime;
    }

    private void SpawnObstacle()
    {
        GameObject animal = animals[(Random.Range(0, animals.Length))];
        float xPos = Random.Range(-xBoundaries, xBoundaries);

        float rotationDirection = rotationDirectionTab[(Random.Range(0, rotationDirectionTab.Length))];
        
        spawnPos = new Vector3(xPos, 0, transform.position.z);
        Instantiate(animal, spawnPos, new Quaternion(
            animal.transform.rotation.x, animal.transform.rotation.y * rotationDirection, animal.transform.rotation.z, animal.transform.rotation.w));

    }
}

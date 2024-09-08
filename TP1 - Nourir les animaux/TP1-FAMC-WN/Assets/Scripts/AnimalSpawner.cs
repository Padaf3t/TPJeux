using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to spawn animal inside the boundary
/// </summary>
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
    private float[] rotationDirectionTab = { -1, 1 };
    //difficulty
    private float timeBetweenDifficulty = 15.0f;
    private float difficultyProgress = 0.0f;
    
        
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();

        xBoundaries = playerController.GetXBoudaries() - 1;

        nextDelay = Random.Range(0.50f * normalDelay, 1.5f * normalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverTrigger.GetIsGameOver())
        {
            UpdateTimer();

            //if we're at the next delay spawn a new animal and select a random delay
            if (progress >= nextDelay)
            {
                progress = 0f;
                SpawnAnimal();
                nextDelay = Random.Range(0.50f * normalDelay, 1.5f * normalDelay);
            }

            //if we're at the next difficulty step, increase difficulty by 5%;
            if (difficultyProgress >= timeBetweenDifficulty)
            {
                difficultyProgress = 0f;
                normalDelay *= 0.95f;
            }
        }
    }

    /// <summary>
    /// Add time to the timer
    /// </summary>
    private void UpdateTimer()
    {
        progress += Time.deltaTime;
        difficultyProgress += Time.deltaTime;
    }

    /// <summary>
    /// Spawn a new animal at a random position and direction
    /// </summary>
    private void SpawnAnimal()
    {
        //Select the animal prefab
        GameObject animal = animals[(Random.Range(0, animals.Length))];

        //Set a random pos
        float xPos = Random.Range(-xBoundaries, xBoundaries);
        Vector3 spawnPos = new Vector3(xPos, 0, transform.position.z);

        //Set a random rotation at -90 or 90
        float rotationDirection = rotationDirectionTab[(Random.Range(0, rotationDirectionTab.Length))];
        Quaternion animalRotation = new Quaternion(
            animal.transform.rotation.x, animal.transform.rotation.y * rotationDirection, animal.transform.rotation.z, animal.transform.rotation.w);

        //Spawn a new animal
        Instantiate(animal, spawnPos, animalRotation);

    }
}

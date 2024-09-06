using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animals;

    private float normalDelay = 2f;
    private float nextDelay;
    private float progress = 0f;
    private Vector3 spawnPos;
    private PlayerController playerController;
    private float xMax;
    private float xMin;
    private float timeBetweenDifficulty = 15.0f;
    private float difficultyProgress = 0.0f;
    
        
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        xMax = playerController.GetMaxDistanceFromZero()-1;
        xMin = -xMax;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        difficultyProgress += Time.deltaTime;

        if (progress >= nextDelay)
        {
            progress = 0f;
            SpawnObstacle();

            nextDelay = Random.Range(0.50f * normalDelay, 1.5f * normalDelay);
        }

        if(difficultyProgress >= timeBetweenDifficulty)
        {
            difficultyProgress = 0f;
            normalDelay *= 0.95f;
        }
    }

    private void SpawnObstacle()
    {
        GameObject animal = animals[(Random.Range(0, animals.Length))];
        var xPos = Random.Range(xMin, xMax);
        spawnPos = new Vector3(xPos, 0, transform.position.z);
        Instantiate(animal, spawnPos, animal.transform.rotation);

    }
}

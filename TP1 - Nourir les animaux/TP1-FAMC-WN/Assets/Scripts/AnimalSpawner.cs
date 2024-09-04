using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    private float normalDelay = 2f;
    private float nextDelay;
    private float progress = 0f;
    private Vector3 spawnPos;
    private PlayerController playerController;
    private float xMax;
    private float xMin;
        
    // Start is called before the first frame update
    void Start()
    {
        xMax = playerController.GetMaxDistanceFromZero();
        xMin = -xMax;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        if (progress >= nextDelay)
        {
            progress = 0f;
            SpawnObstacle();

            nextDelay = Random.Range(0.85f * normalDelay, 1.5f * normalDelay);
        }
    }

    private void SpawnObstacle()
    {
        
    }
}

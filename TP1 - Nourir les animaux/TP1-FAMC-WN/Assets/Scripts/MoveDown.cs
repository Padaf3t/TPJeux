using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public GameObject groundPrefab;
    public static PlayerController playerControllerScript;

    private float speed = 10f;
    private float bottomBound = -40f;
    private float startPosition = 60f;



    // Update is called once per frame
    void Update()
    {//Add if function to deal with game over. 

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (groundPrefab.transform.position.z < bottomBound && gameObject.CompareTag("Ground"))
        {
            SpawnGround();
            Destroy(groundPrefab);
        }

    }

    void SpawnGround()
    {
        Instantiate(groundPrefab, new Vector3(0,0, startPosition), groundPrefab.transform.rotation);
    }
}

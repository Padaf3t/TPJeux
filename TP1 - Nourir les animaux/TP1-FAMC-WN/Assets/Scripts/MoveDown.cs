using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public static PlayerController playerControllerScript;

    private float speed = 2f;
    private float bottomBound = -40f;
    private Vector3 startPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z*4f;
       // InvokeRepeating("SpawnGround", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {//Add if function to deal with game over. 

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < bottomBound && gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void SpawnGround()
    {

    }
}

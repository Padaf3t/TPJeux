using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    private float speed = 10f;
    private float bottomBound = -40f;
    private Vector3 startPosition = new Vector3(0, 0, 60f);



    // Update is called once per frame
    void Update()
    {//Add if function to deal with game over. 

        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (gameObject.CompareTag("Ground") && transform.position.z < bottomBound)
        {
            transform.position = startPosition;
        }

    }
}
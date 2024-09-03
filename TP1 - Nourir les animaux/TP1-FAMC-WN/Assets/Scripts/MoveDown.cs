using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public static PlayerController playerControllerScript;

    private float speed = 2f;
    private float bottomBound = -15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {//Add if function to deal with game over. 

        transform.Translate(Vector3.back * speed * Time.deltaTime);


        if(transform.position.z < bottomBound && gameObject.CompareTag("Ground")
        {
            Destroy(gameObject);
        }
    }
}

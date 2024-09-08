using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    //reference
    private GameOverTrigger gameOverTrigger;
    //movement
    private float speed = -1f; //negative speed needed to go down
    private float bottomBound = -40f;
    private float destroyLimit = -20f;
    private Vector3 startPosition = new Vector3(0, 0, 60f);

    private void Start()
    {
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Move down if it's not a game over
        if (!gameOverTrigger.GetIsGameOver())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            //Restart the position of ground if get to the bottomBound
            if (gameObject.CompareTag("Ground") && transform.position.z < bottomBound)
            {
                transform.position = startPosition;
            }
            //Destroy the animal if get out of bottom screen
            else if(gameObject.CompareTag("Animal") && transform.position.z < destroyLimit)
            {
                Destroy(gameObject);
            }
               
        }
    }
}
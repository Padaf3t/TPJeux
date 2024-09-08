using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    //reference
    private PlayerController playerController;
    private GameOverTrigger gameOverTrigger;
    public Animator animator;
    //speed and movement
    private float xBoudaries;
    private float speed;
    private float maxSpeed = 6f;
    private float minSpeed = 2f;
    private float actualSpeed;
    private float notHungrySpeed = 8f;
    //Eating
    private bool isHungry = true;
    private float eatTimerMax = 1f;
    private float eatTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //Get reference
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();
        animator = gameObject.GetComponent<Animator>();
        xBoudaries = playerController.GetMaxDistanceFromZero();

        //Set a random speed
        speed = Random.Range(minSpeed, maxSpeed);
        if(transform.rotation.y < 0)
        {
            speed = -speed;
        }
        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update()

    {
        animator.SetFloat("Speed_f", actualSpeed);

        if (!gameOverTrigger.GetIsGameOver())
        {
            if (isHungry)
            {
                if (transform.position.x <= -xBoudaries || transform.position.x >= xBoudaries)
                {
                    transform.Rotate(0, 180, 0);
                    speed = -speed;
                    notHungrySpeed = speed * 2;
                }
                actualSpeed = speed;
            }
            else
            {
                CheckEatingStatus();
            }
            transform.Translate(Vector3.right * actualSpeed * Time.deltaTime, Space.World);
        }else
        {
            animator.SetBool("Bark_b", true);
        }
        
    }
    private void CheckEatingStatus()
    {
        if (eatTimer < eatTimerMax)
        {
            animator.SetBool("Eat_b", true);
            eatTimer += Time.deltaTime;
            actualSpeed = 0f;
        }
        else
        {
            animator.SetBool("Eat_b", false);
            actualSpeed = notHungrySpeed;
        }
    }

    public void Manger() {
        isHungry = false;
    }
    public bool GetIsHungry() { return isHungry; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private PlayerController playerController;
    private GameOverTrigger gameOverTrigger;
    private bool isHungry = true;
    private float speed = 4f;
    private float actualSpeed;
    private float notHungrySpeed = 8f;
    private float maxDistanceFromZero;
    public Animator animator;
    private float eatTimerMax = 1f;
    private float eatTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();
        animator = gameObject.GetComponent<Animator>();
        actualSpeed = speed;
        maxDistanceFromZero = playerController.GetMaxDistanceFromZero();
    }

    // Update is called once per frame
    void Update()

    {
        animator.SetFloat("Speed_f", actualSpeed);

        if (!gameOverTrigger.GetIsGameOver())
        {
            if (isHungry )
            {
                
                if (transform.position.x <= -maxDistanceFromZero || transform.position.x >= maxDistanceFromZero)
                {
                    transform.Rotate(0, 180, 0);
                    speed = -speed;
                    notHungrySpeed = -notHungrySpeed;
                    //transform.rotation = new Quaternion(transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
                }
                actualSpeed = speed;
            }
            else
            {
                if(eatTimer < eatTimerMax)
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
            transform.Translate(Vector3.right * actualSpeed * Time.deltaTime, Space.World);
        }else
        {
            animator.SetBool("Bark_b", true);

        }
        
    }
    public void Manger() {
        isHungry = false;
    }
    public bool GetIsHungry() { return isHungry; }
}

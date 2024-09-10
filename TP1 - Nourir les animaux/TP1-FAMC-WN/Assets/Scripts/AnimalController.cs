using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script apply to animal object to bounce them between boundaries
/// and check if it's hungry or not
/// </summary>
public class AnimalController : MonoBehaviour
{
    //reference
    private Animator animator;
    private GameMasterScript gameMaster;
    //speed and movement
    private float xBoudaries;
    private float speed;
    private float maxSpeed = 6f;
    private float minSpeed = 2f;
    private float actualSpeed;
    private float notHungrySpeedMultiplier = 2f;
    //eating
    private bool isHungry = true;
    private float eatTimerMax = 1f;
    private float eatTimer = 0f;
    //score
    private int eatingScore = 5;
    //sound
    public AudioSource audioSource;
    public AudioClip eatAudio;
    public AudioClip barkAudio;


    // Start is called before the first frame update
    void Start()
    {
        //Get reference
        animator = gameObject.GetComponent<Animator>();
        xBoudaries = GameMasterScript.xBoudaries;
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();

        //Set a random base speed
        speed = Random.Range(minSpeed, maxSpeed);
        if (transform.rotation.y < 0)
        {
            speed = -speed;
        }
        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update()

    {
        animator.SetFloat("Speed_f", actualSpeed);

        if (!GameOverTrigger.isGameOver)
        {
            if (isHungry)
            {
                //Rotate the animal when it get to the screen boundaries
                if (transform.position.x <= -xBoudaries || transform.position.x >= xBoudaries)
                {
                    transform.Rotate(0, 180, 0);
                    speed = -speed;
                }
                actualSpeed = speed;
            }
            else
            {
                CheckEatingStatus();
            }
            //move the animal
            transform.Translate(Vector3.right * actualSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            //Set the bark animation to the animal
            animator.SetBool("Bark_b", true);
            audioSource.clip = barkAudio;
            audioSource.loop = true;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

    }

    /// <summary>
    /// Check the eating status, set the animation eating parameter and set the speed
    /// </summary>
    private void CheckEatingStatus()
    {
        //Check if the eat timer is done, if not update it and stop the animal
        if (eatTimer < eatTimerMax)
        { 
            animator.SetBool("Eat_b", true);
            eatTimer += Time.deltaTime;
            actualSpeed = 0f;
        }
        //if done multiply the speed to speed up the animal
        else
        {
            animator.SetBool("Eat_b", false);
            actualSpeed = speed * notHungrySpeedMultiplier;
        }
    }

    /// <summary>
    /// Change the status of isHungry and play the eat sound
    /// </summary>
    public void Manger()
    {
        isHungry = false;
        audioSource.PlayOneShot(eatAudio);
        gameMaster.AddScore(eatingScore);
        
    }

    public bool GetIsHungry() { return isHungry; }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Border")
            Destroy(this.gameObject);
        
    }
}

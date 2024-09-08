using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //reference
    private Animator playerAnim;
    //movement
    private float horizontalInput;
    private float lateralSpeed = 10f;
    private float xBoudaries = 10f;
    //rotation
    private float currentRotation;
    private float rotationSpeed = 150;
    private float rotationDirection;
    //projectile
    [SerializeReference]private GameObject projectileObject;
    private float distanceFromPlayer = 0.7f;
    //sound
    public AudioSource playerAudio;
    public AudioClip throwAudio;
    //particles
    public ParticleSystem throwBoneParticle;

    // Start is called before the first frame update
    void Start()
    {
        //Set the reference
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //let player set action while game is not in game over
        if (!GameOverTrigger.isGameOver)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rotationDirection = horizontalInput;

            SetMovement();

            SetRotation();
            //Throws projectile on space press, play a sound and play particles
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAudio.PlayOneShot(throwAudio);
                throwBoneParticle.Play();

                Vector3 throwPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceFromPlayer);
                Instantiate(projectileObject, throwPosition, projectileObject.transform.rotation);
            }
        }
        else
        {
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",2);
        }
        
    }
    /// <summary>
    /// Set the movement of the player
    /// </summary>
    private void SetMovement()
    {
        //Stops player from moving beyond screen boundaries
        if ((transform.position.x > xBoudaries && horizontalInput > 0) ||
                (transform.position.x < -xBoudaries && horizontalInput < 0))
        {
            horizontalInput = 0;
        }
        transform.Translate(Vector3.right * lateralSpeed * horizontalInput * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// set the rotation of the player
    /// </summary>
    private void SetRotation()
    {
        //if the player is not moving, make the player look forward
        if (horizontalInput == 0)
        {
            if (currentRotation < 0)
            {
                rotationDirection = 1;
            }
            else if (currentRotation > 0)
            {
                rotationDirection = -1;
            }
        }

        //get the rotation degree from the current rotation and input from player
        float newRotation = currentRotation + rotationDirection * rotationSpeed * Time.deltaTime;

        //set the rotation degree between -45degree and 45degree
        currentRotation = Mathf.Clamp(newRotation, -45, 45);

        //rotate the player
        transform.rotation = Quaternion.Euler(0, newRotation, 0);
    }

    /// <summary>
    /// get the xBoundaries of the player
    /// </summary>
    /// <returns>the boundaries to get it in other scripts</returns>
    public float GetXBoudaries() { return xBoudaries; }

}

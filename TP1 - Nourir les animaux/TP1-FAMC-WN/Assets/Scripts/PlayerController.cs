using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameOverTrigger gameOverTrigger;
    //movement variable
    private float horizontalInput;
    private float lateralSpeed = 10f;
    private float maxDistanceFromZero = 10f;
    //rotation
    private float currentRotation;
    private float rotationSpeed = 150;
    private float rotationDirection;
    //Projectile variable
    private float distanceFromPlayer = 0.7f;
    [SerializeReference]private GameObject projectileObject;
    //Animation
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTrigger = GameObject.Find("GameOver Trigger").GetComponent<GameOverTrigger>();
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverTrigger.GetIsGameOver())
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rotationDirection = horizontalInput;

            SetMovement();

            SetRotation();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectileObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceFromPlayer), projectileObject.transform.rotation);
            }
        }
        else
        {
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",2);
        }
        
    }

    private void SetMovement()
    {
        if ((transform.position.x > maxDistanceFromZero && horizontalInput > 0) ||
                (transform.position.x < -maxDistanceFromZero && horizontalInput < 0))
        {
            horizontalInput = 0;
        }
        transform.Translate(Vector3.right * lateralSpeed * horizontalInput * Time.deltaTime, Space.World);
    }

    private void SetRotation()
    {
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

        var newRotation = currentRotation + rotationDirection * rotationSpeed * Time.deltaTime;

        currentRotation = Mathf.Clamp(newRotation, -45, 45);
        transform.rotation = Quaternion.Euler(0, newRotation, 0);
    }

    public float GetMaxDistanceFromZero() { return maxDistanceFromZero; }

}

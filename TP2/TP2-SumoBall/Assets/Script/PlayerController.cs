using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float speed = 10f;
    private Rigidbody rb;
    private Camera cam;
    public static GameObject playerObject;

    //powerUp
    private bool powerUp1IsActive = false;
    private bool powerUp2IsActive = false;
    private float powerUp1Duration;
    private float powerUpStrengthWeight = 300f;
    private int powerUp2Uses = 10;
    private float intangibleTimerStart = 2f;
    private float intangibleTimeRemaining;
    private Collider ballCollider;

    public Material playerMaterial;

    
    private float setIsShinyTrue = 1f;
    private float setIsShinyFalse = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        playerObject = this.gameObject;
        ballCollider = playerObject.GetComponent<Collider>();
        playerMaterial.SetFloat("_isShiny", setIsShinyFalse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelController.instance.GetGameOver())
        {
            verticalInput = Input.GetAxis("Vertical");
            UpdatePowerUp1();
            UpdatePowerUp2();
        }
    }

    private void FixedUpdate()
    {
        if (!LevelController.instance.GetGameOver())
        {
            var dir = cam.transform.forward;
            dir.y = 0;
            dir.Normalize();
            rb.AddForce(dir * speed * verticalInput, ForceMode.Acceleration);
        }
    }

    private void UpdatePowerUp1()
    {
        if (powerUp1IsActive)
        {
            if (powerUp1Duration > 0)
            {
                powerUp1Duration -= Time.deltaTime;
            }
            else
            {
                powerUp1Duration = 0;
                powerUp1IsActive = false;
                this.rb.mass -= powerUpStrengthWeight;
                playerMaterial.SetFloat("_isShiny", setIsShinyFalse);
            }
        }
    }

    private void UpdatePowerUp2()
    {
        
        if (powerUp2IsActive)
        {
            intangibleTimeRemaining -= Time.deltaTime;

            if (intangibleTimeRemaining <= 0)
            {
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && powerUp2Uses > 0)
            {
                intangibleTimeRemaining = intangibleTimerStart;
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
                powerUp2Uses -= 1;
            }
        }
        else if (powerUp2Uses == 0)
        {
            powerUp2IsActive = false;
            playerMaterial.SetFloat("_isShiny", setIsShinyFalse);

        }
    }

    public void EnablePowerUp(PowerUp.PowerUpType type)
    {

        
        playerMaterial.SetFloat("_isShiny", setIsShinyTrue);
        

        if (type == PowerUp.PowerUpType.POWERUP01)
        {
            StartPowerUp1();
        }
        else if(type == PowerUp.PowerUpType.POWERUP02)
        {
            StartPowerUp2();
        }


    }

    private void StartPowerUp1()
    {
        powerUp1Duration += 15;
        if (!powerUp1IsActive)
        {
            powerUp1IsActive = true;
            this.rb.mass += powerUpStrengthWeight;
        }
    }

    private void StartPowerUp2()
    {
        powerUp2Uses = 3;
        powerUp2IsActive = true;
    }


    

}

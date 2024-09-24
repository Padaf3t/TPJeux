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
    private bool powerUp1IsActive;
    private bool powerUp2IsActive = true;
    private float powerUp1Duration;
    private float powerUpStrengthWeight = 15f;
    private int powerUp2Uses = 3;
    private float intangibleTimer = 2f;



    //Timer
    private float progress = 0f;
    private float timerActualPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        playerObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        UpdatePowerUp1();
        UpdatePowerUp2();

    }

    private void FixedUpdate()
    {
        var dir = cam.transform.forward;
        dir.y = 0;
        dir.Normalize();
        rb.AddForce(dir * speed * verticalInput, ForceMode.Force);



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

            }
        }
    }


    //todo
    private void UpdatePowerUp2()
    {
        if (powerUp2IsActive)
        {
            intangibleTimer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && powerUp2Uses > 0)
            {
                if (intangibleTimer > 0)
                {
                    GetComponent<SphereCollider>().isTrigger = true;
                    powerUp2Uses -= 1;
                }
                else
                {
                    GetComponent<SphereCollider>().isTrigger = false;
                    intangibleTimer = 0;
                }
            }
            else if (powerUp2Uses == 0)
            {
                powerUp2IsActive = false;
            }

        }
    }

    //Reste a ajouter le powerUpType dans les paramètres
    public void EnablePowerUp(PowerUp.PowerUpType type)
    {
        if (type == PowerUp.PowerUpType.POWERUP01)
        {
            powerUp1();
        }
        else if(type == PowerUp.PowerUpType.POWERUP02)
        {
            powerUp2();
        }


    }

    private void powerUp1()
    {
        powerUp1Duration += 15;
        if (!powerUp1IsActive)
        {
            powerUp1IsActive = true;
            this.rb.mass += powerUpStrengthWeight;
        }
    }

    private void EndPowerUp1()
    {
        
    }

    private void powerUp2()
    {
        powerUp2Uses = 3;
        powerUp2IsActive = true;
    }


    

}

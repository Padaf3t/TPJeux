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
    }

    private void FixedUpdate()
    {
        rb.AddForce(cam.transform.forward * speed * verticalInput, ForceMode.Force);

    }

    //Reste a ajouter le powerUpType dans les paramètres
    public void EnablePowerUp(PowerUp.PowerUpType type)
    {
        //À implémenter
    }
}

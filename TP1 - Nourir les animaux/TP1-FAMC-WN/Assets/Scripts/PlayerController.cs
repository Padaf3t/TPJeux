using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float lateralSpeed = 10f;
    private float turnDegree;
    private float maxDistanceFromZero = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if((transform.position.x > maxDistanceFromZero && horizontalInput > 0) ||
                (transform.position.x < -maxDistanceFromZero && horizontalInput < 0))
            {
                horizontalInput = 0;
            }

        if(horizontalInput > 0)
        {
            //turnDe
        }
        else if(horizontalInput < 0)
        {

        }
        transform.Translate(Vector3.right * lateralSpeed * horizontalInput * Time.deltaTime, Space.World);
        transform.Rotate(
            new Vector3 (0,Mathf.Clamp(transform.eulerAngles.y, -45, 45),0),
             horizontalInput * turnDegree * Time.deltaTime);
        
        
        
        

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //Spawn bones
        }
    }

    
}

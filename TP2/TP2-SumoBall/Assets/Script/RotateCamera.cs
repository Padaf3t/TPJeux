using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private float rotationSpeed = 40f;
    private float horizontalInput;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down * rotationSpeed * horizontalInput * Time.deltaTime);
    }
}

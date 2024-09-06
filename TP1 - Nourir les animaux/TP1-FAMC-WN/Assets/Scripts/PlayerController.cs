using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float lateralSpeed = 10f;
    private float currentRotation;
    private float rotationSpeed = 150;
    private float rotationDirection;
    private float maxDistanceFromZero = 10f;
    private float distanceFromPlayer = 0.7f;
    public GameObject projectileObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rotationDirection = horizontalInput;



        SetMovement();

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
        SetCurrentRotation(newRotation);





        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectileObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceFromPlayer), projectileObject.transform.rotation);
        }
    }

    private void SetCurrentRotation(float rot)
    {
        currentRotation = Mathf.Clamp(rot, -45, 45);
        transform.rotation = Quaternion.Euler(0, rot, 0);
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

    public float GetMaxDistanceFromZero() { return maxDistanceFromZero; }

}

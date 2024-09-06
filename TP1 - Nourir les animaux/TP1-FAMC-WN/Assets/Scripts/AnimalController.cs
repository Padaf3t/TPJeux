using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private PlayerController playerController;

    private bool isHungry = true;
    private float speed = 4f;
    private float actualSpeed;
    private float maxDistanceFromZero;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        actualSpeed = speed;
        maxDistanceFromZero = playerController.GetMaxDistanceFromZero();
    }

    // Update is called once per frame
    void Update()
        
    {
        if (isHungry)
        {
            if(transform.position.x <= -maxDistanceFromZero || transform.position.x >= maxDistanceFromZero)
            {
                transform.Rotate(0, 180, 0);
                speed = -speed;
                //transform.rotation = new Quaternion(transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
            }
        }
        
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }

    public void Manger() {
        isHungry = false;
    }
}

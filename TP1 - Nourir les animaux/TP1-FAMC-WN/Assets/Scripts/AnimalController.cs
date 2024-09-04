using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private PlayerController playerController;

    private bool isHungry = true;
    private float speed = 4f;
    private float actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update()
        
    {
        if (isHungry && transform.position.x >= -10)
        {
            actualSpeed = speed;
        }
        else if (isHungry && transform.position.x <= 10) {
            actualSpeed = -speed;
        }
        transform.position = new Vector3((transform.position.x + actualSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }

    public void Manger() {
        isHungry = false;
    }
}

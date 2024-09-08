using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private float speed = 20f;
    private float zLimit = 10f;
    
    // Update is called once per frame
    void Update()
    {
        //move and rotate the food
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3 (1,1,1));

        //Destroy the object if not on screen
        if(transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //call manger function if the other collider if an animal and destroy this gameObject
        if(other.gameObject.CompareTag("Animal"))
        {
            AnimalController animalControllerScript = other.gameObject.GetComponent<AnimalController>();
            if (animalControllerScript.GetIsHungry())
            {
                animalControllerScript.Manger();
            }
            Destroy(gameObject);
        }
    }
}

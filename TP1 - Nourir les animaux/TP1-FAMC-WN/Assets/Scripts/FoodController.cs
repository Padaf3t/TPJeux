using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private float speed = 20f;
    private float zLimit = 20f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3 (1,1,1));
        if(transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("animal"))
        {
            other.gameObject.GetComponent<AnimalController>().manger();
            Destroy(gameObject);
        }
    }
}

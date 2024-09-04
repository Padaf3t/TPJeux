using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private bool isHungry = true;
    private float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHungry)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World )
        }
    }

    public void Manger() { }
}

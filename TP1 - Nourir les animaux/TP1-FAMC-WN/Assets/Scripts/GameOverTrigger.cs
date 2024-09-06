using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Animal")){
            if(other.gameObject.GetComponent<AnimalController>().GetIsHungry())
            {
                isGameOver = true;
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}

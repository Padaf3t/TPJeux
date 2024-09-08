using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private bool isGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        //Check if the animal is hungry, set a game over if yes, destroy the animal if not
        if(other.gameObject.CompareTag("Animal")){
            if(other.gameObject.GetComponent<AnimalController>().GetIsHungry())
            {
                isGameOver = true;
            }
        }
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}

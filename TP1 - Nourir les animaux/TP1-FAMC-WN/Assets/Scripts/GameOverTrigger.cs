using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private bool isGameOver = false;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        //Check if the animal is hungry, set a game over if yes, destroy the animal if not
        if(other.gameObject.CompareTag("Animal")){
            if(other.gameObject.GetComponent<AnimalController>().GetIsHungry())
            {
                audioSource.Play();
                isGameOver = true;
            }
        }
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}

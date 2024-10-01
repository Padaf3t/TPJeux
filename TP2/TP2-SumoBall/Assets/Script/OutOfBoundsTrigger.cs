using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LevelController.instance.EnemyOutOfBound();   
        }
        else
        {
            LevelController.instance.GameOver();
          
        }
        Destroy(other.gameObject);
    }
}

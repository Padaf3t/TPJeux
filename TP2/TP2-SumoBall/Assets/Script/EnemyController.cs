using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyObject;
    public Rigidbody rb;

    public enum EnemyLevel
    {
        LVL_UN = 1,
        LVL_DEUX = 2,
        LVL_TROIS = 3,
        LVL_QUATRE = 4,
        LVL_CINQ = 5
    }


    private void FixedUpdate()
    {
        Vector3 vectorPlayer = PlayerController.playerObject.transform.position - this.transform.position;
        rb.AddForce(vectorPlayer, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject InitializeEnemy(EnemyLevel level)
    {

        rb = GetComponent<Rigidbody>();

        if (level == EnemyLevel.LVL_UN)
        {
            rb.mass = 1.0f;
          
        }
        else if (level == EnemyLevel.LVL_DEUX)
        {
            rb.mass = 10.0f;
        }
        else if (level == EnemyLevel.LVL_TROIS)
        {
            rb.mass = 20.0f;
        }
        else if (level == EnemyLevel.LVL_QUATRE)
        {
            rb.mass = 50.0f;
        }
        else 
        {
            rb.mass = 100.0f;
        }

        return this.gameObject;
    }
}

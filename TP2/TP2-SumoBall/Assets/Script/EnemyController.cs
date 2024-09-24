using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyObject;

    private float pullForce = -10f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    private GameObject InitializeEnemy(int level)
    {
        if (level == 1)
        {
            rb.mass = 1.0f;
        }
        else if (level == 2)
        {
            rb.mass = 10.0f;
        }
        else if (level == 3)
        {
            rb.mass = 20.0f;
        }
        else if (level == 4)
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

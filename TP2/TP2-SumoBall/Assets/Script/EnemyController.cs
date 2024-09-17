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

    private void InitializeEnemy()
    {

    }
}

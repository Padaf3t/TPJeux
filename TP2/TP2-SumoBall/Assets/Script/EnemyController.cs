using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyObject;
    public Rigidbody rb;
    private Vector3 baseSize = Vector3.one;
    private Vector3 bigSize = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 smallSize = new Vector3(0.25f, 0.25f, 0.25f);

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
        transform.localScale = baseSize;

        switch (level)
        {
            case EnemyLevel.LVL_UN:
                rb.mass = 1.0f;
                break;
            case EnemyLevel.LVL_DEUX:
                rb.mass = 10.0f;
                transform.localScale = bigSize;
                break;
            case EnemyLevel.LVL_TROIS:
                rb.mass = 20.0f;
                break;
            case EnemyLevel.LVL_QUATRE:
                rb.mass = 50.0f;
                break;
            case EnemyLevel.LVL_CINQ:
                rb.mass = 100.0f;
                transform.localScale = smallSize;
                break;
            default:
                rb.mass = 1.0f;
                break;
        }

        return this.gameObject;
    }
}

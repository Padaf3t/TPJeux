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
    public Material materialBase;
    
    private float meltingLevel;
    private float meltingLevel1 = 0.1f;
    private float meltingLevel2 = 0.3f;
    private float meltingLevel3 = 0.6f;
    private float meltingLevel4 = 0.8f;
    private float meltingLevel5 = 1f;

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
        if (!LevelController.instance.GetGameOver())
        {
            Vector3 vectorPlayer = PlayerController.playerObject.transform.position - this.transform.position;
            rb.AddForce(vectorPlayer, ForceMode.Acceleration);
        }
    }

    public void InitializeEnemy(EnemyLevel level)
    {
        rb = GetComponent<Rigidbody>();

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = Instantiate(materialBase);
        meshRenderer.material = material;

        transform.localScale = baseSize;
        meltingLevel = meltingLevel1;

        switch (level)
        {
            case EnemyLevel.LVL_UN:
                rb.mass = 1.0f;
                break;
            case EnemyLevel.LVL_DEUX:
                rb.mass = 10.0f;
                transform.localScale = bigSize;
                meltingLevel = meltingLevel2;
                break;
            case EnemyLevel.LVL_TROIS:
                rb.mass = 20.0f;
                meltingLevel = meltingLevel3;
                break;
            case EnemyLevel.LVL_QUATRE:
                rb.mass = 50.0f;
                meltingLevel = meltingLevel4;
                break;
            case EnemyLevel.LVL_CINQ:
                rb.mass = 100.0f;
                transform.localScale = smallSize;
                meltingLevel = meltingLevel5;
                break;
            default:
                rb.mass = 1.0f;
                break;
        }

        material.SetFloat("_meltingLevel", meltingLevel);
    }
}

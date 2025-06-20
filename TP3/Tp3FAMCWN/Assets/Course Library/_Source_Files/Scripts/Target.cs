using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour
{
    public int typeIndex;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawnPos = -2;

    public GameObject particle;

    public int scoreValue;
    public bool isBad = false;
    private bool particuleActivated;

    public bool haveBeenLoaded = false;


    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        if (!haveBeenLoaded)
        {
            rb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
            rb.AddForce(Vector3.right * Random.Range(-maxSpeed, maxSpeed) / 12f, ForceMode.Impulse);
            rb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
            transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        }
    }
        
    //Called when Target is Clicked
    private void OnMouseDown(){
        //Checker pref pour voir si on run les particules
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (GameSetting.HasParticule)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
            }
            if (isBad)
            {
                GameManager.instance.UpdateLives(-1);
            }
            
            GameManager.instance.UpdateScore(scoreValue);
            Destroy(gameObject);
            
        }
    }

    //Called when Target reaches the bottom of the screen
    private void OnTriggerEnter(Collider other){
        if (!isBad) GameManager.instance.UpdateLives(-1);
        Destroy(gameObject);
    }
}

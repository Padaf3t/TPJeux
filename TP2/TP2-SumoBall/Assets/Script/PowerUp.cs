using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        POWERUP01 = 0,
        POWERUP02 = 1
    }

    PowerUpType type;

    private void Update()
    {
        transform.Rotate(0,1,0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.GetComponent<PlayerController>().EnablePowerUp(type);
        Destroy(this.gameObject);
    }

    public void SetPowerUpType(int enumPosition)
    {
        switch (enumPosition)
        {
            case 0:
                type = PowerUpType.POWERUP01;
                break;
            case 1:
                type = PowerUpType.POWERUP02;
                break;
            default:
                break;
        }
            
        
    }

}

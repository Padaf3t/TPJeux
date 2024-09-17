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


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerController.playerObject.GetComponent<PlayerController>().EnablePowerUp(type);
        Destroy(this);
    }

}

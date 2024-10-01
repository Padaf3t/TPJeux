using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnHit : MonoBehaviour
{
    public Material playerMaterial;
    public Color redColor = Color.red;
    public float duration = 0.5f;

    private float blendFactor = 0;
    private float blendSpeed = 2;

    private void Update()
    {
        if(blendFactor > 0)
        {
            blendFactor -=blendSpeed * Time.deltaTime;
            blendFactor = Mathf.Max(blendFactor, 0);
            playerMaterial.SetFloat("_BlendFactor", blendFactor);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            StartCoroutine(ChangeColor());
        }
    }

    private IEnumerator ChangeColor()
    {
        blendFactor = 1;
        playerMaterial.SetColor("_damagedColor", redColor);
        yield return new WaitForSeconds(duration);
        blendFactor = 0;
        playerMaterial.SetFloat("_BlendFactor", blendFactor);

    }
}

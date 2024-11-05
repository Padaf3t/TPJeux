using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    /// <summary>
    /// Make the gameobject with the script to be not destroy on load
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

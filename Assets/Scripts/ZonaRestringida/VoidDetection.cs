using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDetection : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            Debug.Log("Vida perdida");
            //Resto de codigo como hacer tp a personaje a respawn o lo que sea
        }
        
    }
}

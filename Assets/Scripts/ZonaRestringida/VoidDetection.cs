using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDetection : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField] CharacterStats charStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            Debug.Log("Vida perdida");
            charStats.LoseLife();
        }
        
    }
}

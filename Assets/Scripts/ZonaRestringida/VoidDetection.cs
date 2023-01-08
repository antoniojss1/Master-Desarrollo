using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDetection : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField] CharacterStats charStats;
    private void Awake()
    {
        if (charStats == null)
        {
            charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            Debug.Log("Vida perdida");
            charStats.LoseLife();
        }
        
    }
}

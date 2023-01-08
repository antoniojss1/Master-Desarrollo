using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            Debug.Log("Fin");
            SceneManager.LoadScene("MainMenu");
        }

    }
}

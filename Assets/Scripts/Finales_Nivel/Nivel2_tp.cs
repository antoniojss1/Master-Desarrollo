using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel2_tp : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            Debug.Log("Entrando en Nivel 2");
            SceneManager.LoadScene("Nivel2_Embarcadero");
        }

    }
}

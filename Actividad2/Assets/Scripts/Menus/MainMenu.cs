using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Nivel1_Muelle");
    }
}

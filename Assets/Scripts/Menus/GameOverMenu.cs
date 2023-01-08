using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] AudioSource gameOverSound;

    private void Start()
    {
        gameOverSound.Play();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Nivel1_Muelle");
    }
}

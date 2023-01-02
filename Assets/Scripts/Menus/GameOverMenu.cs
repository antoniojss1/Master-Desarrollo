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

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("EscenaPruebas");
    }
}

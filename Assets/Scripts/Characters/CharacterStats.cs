using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private Text textElement;
    [SerializeField] Transform playerRespawn;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);   
    }
    private void Start()
    {
        textElement.text = lives.ToString();
    }
    public void CheckLives()
    {
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        else
        {
            teleportPlayer();
        }
    }

    public void LoseLife()
    {
        lives -= 1;
        textElement.text = lives.ToString();
        CheckLives();
    }

    public void SetLives(int newLives)
    {
        lives = newLives;
    }

    public int GetLives()
    {
        return lives;
    }

    public void setRespawnPoint(Transform newRespawn)
    {
        playerRespawn = newRespawn;
    }

    public void teleportPlayer()
    {
        //Deshabiltiar character controller para que permita modificar la posicion directamente
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        transform.position = playerRespawn.position;  //tp a respawn
        cc.enabled = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

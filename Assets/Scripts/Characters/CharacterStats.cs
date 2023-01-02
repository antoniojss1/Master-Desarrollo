using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private Text textElement;

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
    }

    public void LoseLife()
    {
        lives -= 1;
        textElement.text = lives.ToString();
        CheckLives();
    }

    public void RestartLives(int newLives)
    {
        lives = newLives;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

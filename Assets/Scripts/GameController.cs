using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // 单例
    public static GameController instance;

    public Text scoreText;
    public GameObject gameOverText;

    public bool gameOver = false;
    private int score = 0;
    public float scrollSpeed = -2.0f;

    private void Awake()
    {
        // 初始化单例
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // ??
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = score.ToString();
    }

    public void BirdDied()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
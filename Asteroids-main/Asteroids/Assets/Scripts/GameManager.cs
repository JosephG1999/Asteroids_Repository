using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    
    public Player player;

    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI livesTracker;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    
    private void Start()
    {
        retryButton.gameObject.SetActive(false);
        gameOverText.color = new Color32(255, 255, 255, 0);
        finalScore.color = new Color32(255, 255, 255, 0);
    }
    
    public void PlayerDied()
    {
        if (lives > 1)
        {
            this.lives--;
            Invoke(nameof(Respawn), 1.5f);
        }
        else
        {
            this.lives--;
            GameOver(player);
        }
        
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver(Player player)
    {
        player.gameObject.SetActive(false);
        scoreBoard.color = new Color32(255, 255, 255, 0);
        livesTracker.color = new Color32(255, 255, 255, 0);
        //Invoke("GameOverTextOn", 3.0f);
        StartCoroutine(GameOverTextOn(gameOverText, finalScore));
    }
    
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.score += 100;
    }

    public void increaseScore()
    {
        this.score += 100;
    }

    private IEnumerator GameOverTextOn(TextMeshProUGUI text, TextMeshProUGUI text2)
    {
        yield return new WaitForSeconds(2);
        text.color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(3);
        text2.color = new Color32(255, 255, 255, 255);
        retryButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        scoreBoard.text = "Score: " + score.ToString();
        livesTracker.text = "Lives: " + lives.ToString();
        finalScore.text = "Final Score \n" + score.ToString();
    }
}

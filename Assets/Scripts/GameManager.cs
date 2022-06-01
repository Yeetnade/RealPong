using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _playerScore1;
    private int _playerScore2;
    public Ball ball;
    public PlayerPaddles playerPaddle1;
    public PlayerPaddles playerPaddle2;

    public Text playerScoreText1;
    public Text playerScoreText2;

    [SerializeField]
    private GameObject gameOverUI1;
    [SerializeField]
    private GameObject gameOverUI2;

    public AudioSource scoreSource1;
    public AudioSource scoreSource2;
    public AudioClip scoreSound;    

    public GameObject player1;
    public GameObject player2;

    public GameObject gameBoundaries;
  
    
    public GameObject endBoundaries;

    public void PlayerScores1()
    {
        _playerScore1++;
        this.playerScoreText1.text = _playerScore1.ToString();
        if (_playerScore1 == 11)
        {
            gameOverUI2.SetActive(true);
            endGame();
        }
        else
        {
            scoreSource1.PlayOneShot(scoreSound);
            ResetRound();
        }
        
    }

    public void PlayerScores2()
    {
        _playerScore2++;
        this.playerScoreText2.text = _playerScore2.ToString();
        if (_playerScore2 == 11)
        {
            gameOverUI1.SetActive(true);
            endGame();
        }
        else
        {
            scoreSource2.PlayOneShot(scoreSound);
            ResetRound();
        }
        
    }

    private void ResetRound()
    {
        ball.rb2.velocity = Vector2.zero;
        StartCoroutine(WaitBeforeReset());
       
    }

    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(2f);
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    public void endGame()
    {
        this.ball.ResetPosition();
        this.ball.AddStartingForce();

        player1.SetActive(false);
        player2.SetActive(false);

        gameBoundaries.SetActive(false);
        endBoundaries.SetActive(true);
    }
}

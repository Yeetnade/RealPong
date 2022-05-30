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

    public void PlayerScores1()
    {
        _playerScore1++;
        this.playerScoreText1.text = _playerScore1.ToString();
        if (_playerScore1 == 11)
        {
            this.ball.ResetPosition();
            gameOverUI2.SetActive(true);

        }
        else
        {
            ResetRound();
        }
        
    }

    public void PlayerScores2()
    {
        _playerScore2++;
        this.playerScoreText2.text = _playerScore2.ToString();
        if (_playerScore2 == 11)
        {
            this.ball.ResetPosition();
            gameOverUI1.SetActive(true);

        }
        else
        {
            ResetRound();
        }
        
    }

    private void ResetRound()
    {
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

}

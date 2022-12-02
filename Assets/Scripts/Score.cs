using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player, opponent, playerScoreText, opponentScoreText;
    public int playerScore = 0;
    public int opponentScore = 0;

    private void OnCollisionEnter2D(Collision2D collision) // if ball enters collision
    {
        if (transform.position.x < player.transform.position.x) //check if left of player
        {
            opponentScore += 1; // Increase opponent score
            opponentScoreText.GetComponent<TextMeshProUGUI>().text = opponentScore.ToString(); //Update Score Text

            RestartBall(0);
        }

        if (transform.position.x > opponent.transform.position.x) // check if right of opponent
        {
            playerScore += 1; //increase player score
            playerScoreText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString(); //Update Score Text

            RestartBall(1);
        }
    }

    private void RestartBall(int direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // Zeros velocity
        transform.position = new Vector2(0, 0);
        GetComponent<BallMovement>().StartDelay(direction);
    }
}

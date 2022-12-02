using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject Player;
    public float speed; //Ball Speed

    void Start()
    {
        StartDelay(0); //Runs one time start
    }

    public void StartDelay(int direction)
    {
        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)) // if ball is not moving
        {
            StartCoroutine(Delay(direction)); //apply delay before moving ball in given direction
        }
    }

    IEnumerator Delay(int direction) //If ball at starting position, delay for 1.5 seconds
    {
        yield return new WaitForSeconds(1.5f);

        if (direction == 0) GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0); //Sets initial velocity to towards player if direction = 0
        else GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0); //Sets initial velocity towards opponent if direction != 0
    }

    // Collisions with Player and Opponent vvv
    void OnCollisionEnter2D(Collision2D col) //If collision detected
    {
        if (col.gameObject.name == "Player") //Hits Player
        {
            float yFac = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); // Calculate hit factor

            Vector2 dir = new Vector2(1, yFac).normalized;  // Calculate direction, make length=1 via .normalized
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Opponent") //Hits Player
        {
            float yFac = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); // Calculate hit factor

            Vector2 dir = new Vector2(-1, yFac).normalized;  // Calculate direction, make length=1 via .normalized
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // |  1 <- at the top of the racket
        // |  0 <- at the middle of the racket
        // | -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}

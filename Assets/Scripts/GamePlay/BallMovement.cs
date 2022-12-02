using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
	[SerializeField] private float ballStartVelocity; //Set in inspector

	void Start()
    {
        StartDelay(0); //runs one time at start
    }

    public void StartDelay(int ballStartDirection)
    {
        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)) // if ball is not moving
        {
            StartCoroutine(Delay(ballStartDirection)); //apply delay before moving ball in given direction
        }
    }

    IEnumerator Delay(int ballStartDirection) //If ball at starting position, delay for 1.5 seconds
    {
        yield return new WaitForSeconds(1.5f);

        if (ballStartDirection == 0) GetComponent<Rigidbody2D>().velocity = new Vector2(-ballStartVelocity, 0); //Sets initial velocity to be towards player if ballStartDirection = 0
		else GetComponent<Rigidbody2D>().velocity = new Vector2(ballStartVelocity, 0); //Sets initial velocity towards opponent if ballStartDirection != 0
	}

    // If ball enters collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player") //if hits playerObject
        {
            float yFactor = HitDirection(transform.position, col.transform.position, col.collider.bounds.size.y); // Calculate direction angle

            Vector2 ballAngle = new Vector2(1, yFactor).normalized;  // make length=1 via .normalized
			GetComponent<Rigidbody2D>().velocity = ballAngle * ballStartVelocity;
        }

        if (col.gameObject.name == "Opponent") //if hits opponentObject
        {
            float yFactor = HitDirection(transform.position, col.transform.position, col.collider.bounds.size.y); // Calculate direction angle

			Vector2 ballAngle = new Vector2(-1, yFactor).normalized;  //make length=1 via .normalized
			GetComponent<Rigidbody2D>().velocity = ballAngle * ballStartVelocity;
        }
    }

    float HitDirection(Vector2 ballPosition, Vector2 racketPositon, float racketHeight)
    {
        // |  1 <- at the top of the racket
        // |  0 <- at the middle of the racket
        // | -1 <- at the bottom of the racket
        return (ballPosition.y - racketPositon.y) / racketHeight;
    }
}

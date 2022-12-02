using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody2D rigidBody;
    public float speed, lerpSpeed, distanceFactor;


    void FixedUpdate()
    {
        // If ball + or - offset is greater than opponent
        if ((ball.transform.position.y + distanceFactor) > transform.position.y && (ball.transform.position.y - distanceFactor) > transform.position.y)
        {
            if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector2.zero; //makes sure velocity is zero
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime); //increase velocity to match with ball y position
        }
        // If ball + or - offset is lesser than than opponent
        if ((ball.transform.position.y + distanceFactor) < transform.position.y && (ball.transform.position.y - distanceFactor) < transform.position.y)
        {
            if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero; //makes sure velocity is zero
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);//increase velocity to match with ball y position
        }
        else
        {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime); //increase velocity to match with ball y position
        }
    }
}
